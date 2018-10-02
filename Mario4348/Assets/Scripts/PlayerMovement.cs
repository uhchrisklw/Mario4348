using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D m_Rigidbody;
    private Animator myAnimation;
    float m_Speed;

    SpriteRenderer m_SpriteRenderer;
    
    private bool grounded;
    private float fallSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();

        //Fetch Animation component 
        myAnimation = GetComponent<Animator>();

        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        //Set the speed of the GameObject
        m_Speed = 1.0f;
        fallSpeed = 1.0f;
    }

    private void FixedUpdate()
    {
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

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (m_SpriteRenderer.flipX == true)
            {
                m_SpriteRenderer.flipX = false;
            }
            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            myAnimation.SetFloat("Speed", m_Speed);
            m_Rigidbody.velocity = transform.right * m_Speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (m_SpriteRenderer.flipX == false)
            {
                m_SpriteRenderer.flipX = true;
            }
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            myAnimation.SetFloat("Speed", m_Speed);
            m_Rigidbody.velocity = -transform.right * m_Speed;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            myAnimation.SetFloat("Speed", 0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            myAnimation.SetFloat("Speed", 0);
        }
    }



    //   private Rigidbody2D myRigidBody;
    //   [SerializeField]
    //   private float moveSpeed;
    //   private float moveVelocity;
    //   [SerializeField]
    //   private float jumpHeight;
    //   [SerializeField]
    //   private bool grounded;
    //   private float fallSpeed;
    //   public Transform groundCheck;
    //   public float groundCheckRadius;
    //   public LayerMask whatIsGround;
    //   private Animator myAnimation;


    //// Use this for initialization
    //void Start () {
    //       myRigidBody = GetComponent<Rigidbody2D>();
    //       myAnimation = GetComponent<Animator>();
    //}

    //   // physics of jumping
    //   private void FixedUpdate() {
    //       grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    //       if (grounded == true)
    //       {
    //           myAnimation.SetBool("Grounded", true);
    //       }
    //       else if (grounded == false)
    //       {
    //           myAnimation.SetBool("Grounded", false);
    //       }
    //   }

    //   // Update is called once per frame
    //   void Update () {
    //       var vertical = Input.GetAxis("Vertical");
    //       myAnimation.SetFloat("Speed", vertical);

    //       var horizontal = Input.GetAxis("Horizontal");
    //       myAnimation.SetFloat("Speed", horizontal);
    //       moveVelocity = 0f;

    //       if (Input.GetKey(KeyCode.RightArrow))
    //       {
    //           moveVelocity = moveSpeed;
    //       }

    //       if (Input.GetKey(KeyCode.LeftArrow))
    //       {
    //           moveVelocity = -moveSpeed;
    //           //{
    //           //    myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
    //           //}
    //           //if (Input.GetKey(KeyCode.Space))
    //           //{
    //           //    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpHeight);
    //           //}
    //           //myAnimation.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
    //           //if (myRigidBody.velocity.x > 0)
    //           //{
    //           //    transform.localScale = new Vector3(1f, 1f, 1f);
    //           //}
    //           //else if (myRigidBody.velocity.x < 0)
    //           //{
    //           //    transform.localScale = new Vector3(-1f, -1f, -1f);
    //           //}
    //       }

    //   }
}
