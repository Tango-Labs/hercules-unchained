using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    public GameObject[] backgrounds;

    public GameObject ghost3;
    public GameObject ghost51;
    public GameObject ghost52;

    private int levelIndex = 0;

    private bool hasJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;

        ghost3.SetActive(false);
        ghost51.SetActive(false);
        ghost52.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        int yDist = 0;

        if (transform.position.x > 1498 && levelIndex == 3)
        {
            updateBackground();
            ghost51.SetActive(true);
            ghost52.SetActive(true);
        }
        else if (transform.position.x > 1048 && levelIndex == 2)
        {
            updateBackground();
            ghost3.SetActive(false);
        }
        else if (transform.position.x > 598 && levelIndex == 1)
        {
            updateBackground();
            ghost3.SetActive(true);
        }
        else if (transform.position.x > 148 && levelIndex == 0)
        {
            updateBackground();
        }

        if (transform.position.x > 1048 && transform.position.x < 1498)
        {
            yDist = -10;
        }

        if (transform.position.x > 1498 && transform.position.x < 1500 && hasJumped == false)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 25);
            hasJumped = true;
        }

        transform.position = new Vector3(transform.position.x + distanceToMove, yDist, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }

    void updateBackground()
    {
        backgrounds[levelIndex].SetActive(false);
        levelIndex++;
    }
}
