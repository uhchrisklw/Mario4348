using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float maxSpeed = 3;
    public float speed = 5f;
    public float jumpPower = 200f;
    public bool grounded;
    private Rigidbody2D m_RigidBody;

    private Animator m_Animator;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_Animator.SetBool("Grounded", grounded);
        m_Animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            m_RigidBody.AddForce(Vector2.up * jumpPower);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        // move player
        m_RigidBody.AddForce((Vector2.right * speed) * h);

        // limit speed of player
        if (m_RigidBody.velocity.x > maxSpeed)
        {
            m_RigidBody.velocity = new Vector2(maxSpeed, m_RigidBody.velocity.y);
        }

        if (m_RigidBody.velocity.x < -maxSpeed)
        {
            m_RigidBody.velocity = new Vector2(-maxSpeed, m_RigidBody.velocity.y);
        }
    }
}
