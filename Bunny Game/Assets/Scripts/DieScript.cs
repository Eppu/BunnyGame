using UnityEngine;
using System.Collections;


public class DieScript : MonoBehaviour
{
    public float targetScale = 1.0f;
    public float shrinkSpeed = 10.0f;
    //public bool shrinking;
    public GameObject splat;

    void Update()
    {
        if(GameObject.Find("Player").GetComponent<Player>().isDead)
        {
            splat.transform.localScale = Vector3.Lerp(splat.transform.localScale,
            new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
            
            if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("mainmenu");
            }
        }
    }

    
}
