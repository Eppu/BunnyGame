using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float jumpSpeed = 100.0f;
	public float runSpeed = 5.0f;
    public bool isDead = false;
    public bool hasWon = false;

	private Rigidbody2D rb2d;


	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update() 
	{
        if (isDead == false && hasWon == false)
        {
            UpdatePlayerPosition();
        }
		if(isDead == false && hasWon == false && Input.GetKeyDown(KeyCode.UpArrow))
          
		{
            PlayerJump();
		}

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("You died...");
            isDead = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
            hasWon = true;

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

}
