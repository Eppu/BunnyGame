using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour
{
    public float speed;

	void Start ()
    {
	
	}
	

	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
