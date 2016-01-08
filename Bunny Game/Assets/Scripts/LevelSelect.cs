using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
    public float speed = 0.2f;


	void Update ()
    {
        transform.position = new Vector3(transform.position.x, 2 + Mathf.Sin(Time.time * speed), transform.position.z);
    }
}
