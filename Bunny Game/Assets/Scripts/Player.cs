using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float jumpSpeed = 100.0f;
	public float runSpeed = 5.0f;
    public float rotateSpeed = 3.0f;
    public float width = 5.0f;
    public bool isDead = false;
    public bool hasWon = false;
    public bool hasFallen = false;
    public GameObject gameManager;
    public Camera main;
    Animator anim;
    public AudioSource[] sounds;
    public AudioSource noise1;
    public AudioSource noise2;
    public AudioSource noise3;

    Transform backFoot;

    private Rigidbody2D rb2d;
    BoxCollider2D playerCollider;

    public float jumpX;
    public float jumpY;
    public float runX;
    public float runY;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        backFoot = transform.FindChild("BackFoot").transform;
        gameManager = GameObject.Find("PointsManager");
        anim = GetComponent<Animator>();
        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0];
        noise2 = sounds[1];
        noise3 = sounds[2];
    }

	void Update() 
	{
        if (isDead == false && hasWon == false)
        {
            anim.SetInteger("Direction", 1);
            UpdatePlayerPosition();
            playerCollider.size = new Vector2(runX, runY);
        }
        if (IsGrounded())
        {
            if (isDead == false && hasWon == false && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                PlayerJump();   
            }
        }
        else
        {
            anim.SetInteger("Direction", 0);
           playerCollider.size = new Vector2(jumpX, jumpY);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            noise1.Play();
            Debug.Log("You died...");
            noise3.Stop();
            DieMe();  
            rb2d.isKinematic = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            noise2.Play();
            Debug.Log("You win!");
            hasWon = true;
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Detector")
        {
            hasFallen = true;
            Debug.Log("You hit the pit detector!");
        }
    }

    void UpdatePlayerPosition()
    {
        transform.Translate(runSpeed * Time.deltaTime, 0f, 0f);
    }

    void DieMe()
    {
        if (!isDead)
        {
            if (gameManager.GetComponent<RetryCounter>() )
                gameManager.GetComponent<RetryCounter>().IncrementDeathCounter() ;
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
