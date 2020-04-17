using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject startTitle;
    public Text scoreText;
    public Text narrator;
    public GameObject player;

    private float nextActionTime = 0f;
    public float period = 0.5f;

    private bool gameHasStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameHasStarted = false;
        startTitle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int playerX = (int) player.transform.position.x*1000;
        playerX = playerX / 100;
        scoreText.text = playerX.ToString();

        if (Time.time > nextActionTime && gameHasStarted == false)
        {
            nextActionTime += period;
            if (startTitle.activeInHierarchy == true)
            {
                startTitle.SetActive(false);
            }
            else
            {
                startTitle.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTitle.SetActive(false);
            gameHasStarted = true;
        }
    }
}
