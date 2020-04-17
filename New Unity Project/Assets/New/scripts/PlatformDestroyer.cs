﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private GameObject groundDestructionPoint;


    // Start is called before the first frame update
    void Start()
    {
        groundDestructionPoint = GameObject.Find("GroundDestructionPoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < groundDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
