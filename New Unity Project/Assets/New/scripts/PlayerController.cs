using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        moveSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 10);
        }

        if (moveSpeed < 15)
        {
            moveSpeed = moveSpeed * 1.00005f;
        }

    }
}

