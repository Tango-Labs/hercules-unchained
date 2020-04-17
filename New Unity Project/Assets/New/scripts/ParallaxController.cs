using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    private float startPos;
    public GameObject camera;
    public float parralaxConstant;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (camera.transform.position.x * parralaxConstant);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
