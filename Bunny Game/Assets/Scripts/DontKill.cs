using UnityEngine;
using System.Collections;

public class DontKill : MonoBehaviour {

	
	void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	

}
