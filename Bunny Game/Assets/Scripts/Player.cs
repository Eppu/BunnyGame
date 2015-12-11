using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float jumpSpeed = 100.0f;
	public float runSpeed = 5.0f;
    public float width = 5.0f;
    public bool isDead = false;
    public bool hasWon = false;
    public bool hasFallen = false;
    public Text deathCount;

    static int timesDied = 0;

    Transform backFoot;

    private Rigidbody2D rb2d;



	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
        backFoot = transform.FindChild("BackFoot").transform;
    }

	void Update() 
	{
        if (isDead == false && hasWon == false)
        {
            UpdatePlayerPosition();
        }

        if (IsGrounded())
        {
            if (isDead == false && hasWon == false && Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayerJump();
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("You died...");
            isDead = true;
            rb2d.isKinematic = true;
            timesDied++;
            Debug.Log(timesDied);
            deathCount.text = "Retry Count: " + timesDied.ToString();
        }
        if (collision.gameObject.tag == "Goal")
        {
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
