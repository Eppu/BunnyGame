using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
    float scale = 0.5f;
    float minScale = 0.5f;
    float maxScale = 1.0f;
    float scaleSpeed = 0.5f;
    public 

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("runner");
        }

    }
}
