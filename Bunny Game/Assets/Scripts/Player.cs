using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float jumpSpeed = 100.0f;
	public float runSpeed = 5.0f;
    public bool isDead = false;

	private Rigidbody2D rb2d;


	void Start ()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
        if (isDead == false)
        {
            transform.Translate(runSpeed * Time.deltaTime, 0f, 0f);
        }
		if(isDead == false && Input.GetKeyDown(KeyCode.UpArrow))
          
		{
			rb2d.AddForce(Vector2.up * jumpSpeed);
		}
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isDead = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
            isDead = true;

        }
    }

}
