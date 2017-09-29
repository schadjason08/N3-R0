using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    private RigidBody2D myRigidbody;

    [SerializedField]
    private float movementSpeed;

    private bool faceingRight;


	// Use this for initialization
	void Start () 
    {
        faceingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float horizontal = Input.GetAxis("Horizontal");


        HandleMovement();

        Flip(horizontal);
	}

    private void HandleMovement(float horizontal)
    {


        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);



    }

    private void Flip(float horizontal)
    {

        if (horizontal > 0 && !facingRight || horizontal < 0 && faceingRight)
        {
            faceingRight = !faceingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }

    }
}
