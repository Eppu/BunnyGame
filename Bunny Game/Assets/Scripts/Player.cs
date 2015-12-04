using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float jumpSpeed = 100.0f;
	public float runSpeed = 5.0f;

	private Rigidbody2D rb2d;


	void Start ()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		transform.Translate (runSpeed * Time.deltaTime, 0f, 0f);
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			rb2d.AddForce(Vector2.up * jumpSpeed);
		}
	}

}
