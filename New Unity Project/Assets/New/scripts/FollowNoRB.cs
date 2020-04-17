using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNoRB : MonoBehaviour
{

    public GameObject followWho;
    public int withDistance;
    public int stopChasingAt;
    private bool hasFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < stopChasingAt)
        {
            if (transform.position.x < followWho.transform.position.x - withDistance)
            {
                Vector3 delta = new Vector3(followWho.transform.position.x - withDistance - transform.position.x, 0, 0);
                transform.Translate(delta);
            }
        } else {
            if (!hasFinished)
            {
                if (tag == "Stage2" || tag == "Stage4O")
                {
                    gameObject.AddComponent<Rigidbody2D>();
                }
                hasFinished = true;
            }
        }

    }
}
