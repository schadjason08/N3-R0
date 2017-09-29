using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {



    private static playerMovement instance;

    public static playerMovement Instance;
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectofType<Player>();
            }
            return instance;
        }
    }

    private Animator myAnimator;

    [SerializeField]
    private Transform bulletPos;



    private RigidBody2D myRigidbody;

    [SerializedField]
    private float movementSpeed;

    private bool faceingRight;

    private bool attack;

    [SerializeField]
    private GameObject gunPrefab;

    public Rigidbody2D MyRigidBody { get; set; }

    public bool Attack { get; set; }




	// Use this for initialization
	void Start () 
    {
        faceingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();

	}
	
    void Update()
    {
    HandleInput();
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        float horizontal = Input.GetAxis("Horizontal");


        HandleMovement();

        Flip(horizontal);

        HandleAttacks();

        ResetValues();
	}

    private void HandleMovement(float horizontal)
    {
    if (!this.myAnimator.GetCurrentAnimatorsStateInfo(0).IsTag("Attack"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }


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

    private void HandleAttacks()
    {
        if (attack && (!this.myAnimator.GetCurrentAnimatorsStateInfo(0).IsTag("Attack"))
        {
        myAnimator.SetTrigger("attack");
        myRigidbody.velocity = Vector2.zero;
        }


    }

    private void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
        attack = true;
        }
        
    }

    private void ResetValues()
    {

    attack = false;

    }
}
