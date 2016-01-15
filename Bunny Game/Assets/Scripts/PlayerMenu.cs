﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMenu : MonoBehaviour
{

    public float jumpSpeed = 100.0f;
    public float runSpeed = 5.0f;
    public float rotateSpeed = 3.0f;
    public float width = 5.0f;
    public bool isDead = false;
    public bool hasWon = false;
    public bool hasFallen = false;
    public bool facingRight = true;
    public GameObject gameManager;
    public Camera mainCam;
    Animator anim;
    Animator camAnim;

    Transform backFoot;

    private Rigidbody2D rb2d;



    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        backFoot = transform.FindChild("BackFoot").transform;
        gameManager = GameObject.Find("PointsManager");
        anim = GetComponent<Animator>();
        camAnim = mainCam.GetComponent<Animator>();

    }

    void Update()
    {
        anim.SetInteger("Direction", 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            anim.SetInteger("Direction", 1);
            facingRight = true;
            Debug.Log(facingRight);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * runSpeed * Time.deltaTime);
            anim.SetInteger("Direction", 2);
            facingRight = false;
            Debug.Log(facingRight);
        }
        if (IsGrounded())
        {
            if (isDead == false && hasWon == false && Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayerJump();
            }
        }
        if(!IsGrounded())
        {
            anim.SetInteger("Direction", 4);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Play")
        {
            Application.LoadLevel("runner");
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Credits" && !facingRight)
        {
            camAnim.Play("CamMovement");
            Debug.Log("You hit the Credit trigger from the right!");
        }
        else if (trigger.gameObject.tag == "Credits" && facingRight)
        {
            camAnim.Play("CamReverse");
            Debug.Log("You hit the Credit trigger from the left!");
        }
    }



    void DieMe()
    {
        if (!isDead)
        {
            if (gameManager.GetComponent<RetryCounter>())
                gameManager.GetComponent<RetryCounter>().IncrementDeathCounter();
        }
        isDead = true;

    }

    void PlayerJump()
    {
        rb2d.AddForce(Vector2.up * jumpSpeed);
    }

    bool IsGrounded()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(backFoot.position, Vector2.right, width);

        Debug.DrawLine(backFoot.position,
                       backFoot.position + Vector3.right * width,
                       Color.red);

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform.tag == "Ground")
            {
                return true;
            }
        }
        return false;
    }

}
