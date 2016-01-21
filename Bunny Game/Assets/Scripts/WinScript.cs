using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour
{
    public float targetScale = 1.0f;
    public float shrinkSpeed = 10.0f;
    public GameObject win;
    public string levelName;

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().hasWon)
        {
            win.transform.localScale = Vector3.Lerp(win.transform.localScale,
            new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R)) 
            {
                Application.LoadLevel(levelName);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("mainmenu");
            }
        }
    }


}
