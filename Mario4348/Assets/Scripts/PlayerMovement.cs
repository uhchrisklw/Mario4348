using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float moveSpeed;
    private float moveVelocity;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private bool grounded;
    private float fallSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private Animator myAnimation;


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
	}

    // physics of jumping
    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (grounded == true)
        {
            myAnimation.SetBool("Grounded", true);
        }
        else if (grounded == false)
        {
            myAnimation.SetBool("Grounded", false);
        }
    }

    // Update is called once per frame
    void Update () {
        var vertical = Input.GetAxis("Vertical");
        myAnimation.SetFloat("Speed", vertical);

        var horizontal = Input.GetAxis("Horizontal");
        myAnimation.SetFloat("Speed", horizontal);
        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -moveSpeed;
            //{
            //    myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
            //}
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpHeight);
            //}
            //myAnimation.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
            //if (myRigidBody.velocity.x > 0)
            //{
            //    transform.localScale = new Vector3(1f, 1f, 1f);
            //}
            //else if (myRigidBody.velocity.x < 0)
            //{
            //    transform.localScale = new Vector3(-1f, -1f, -1f);
            //}
        }
        
    }
}
