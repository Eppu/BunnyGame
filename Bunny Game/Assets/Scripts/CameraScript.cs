using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	void LateUpdate ()
    {
       transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
}
