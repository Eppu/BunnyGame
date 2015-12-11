using UnityEngine;
using System.Collections;

public class UnchildWhenDead : MonoBehaviour
{


	void Update ()
    {
       if(GameObject.Find("Player").GetComponent<Player>().hasFallen)
        {
            DetachCamera();
        }
    }

    void DetachCamera()
    {
        transform.parent = null;
    }
}
