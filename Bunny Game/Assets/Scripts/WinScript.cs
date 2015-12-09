﻿using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour
{

    public float targetScale = 1.0f;
    public float shrinkSpeed = 10.0f;
    public GameObject win;

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().hasWon)
        {
            win.transform.localScale = Vector3.Lerp(win.transform.localScale,
            new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
        }
    }


}