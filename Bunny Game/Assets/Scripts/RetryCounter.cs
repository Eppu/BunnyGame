using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryCounter : MonoBehaviour
{
    static int timesDied = 0;
    public Text deathCount;
    public GameObject playerObject;


	void Update ()
    {
        playerObject = GameObject.Find("Player");

    }

    public void IncrementDeathCounter()
    {
		timesDied++;
        Debug.Log(timesDied);
        deathCount.text = "Times Died: " + timesDied.ToString();

    }

}
