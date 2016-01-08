using UnityEngine;
using System.Collections;

public class LogoScaler : MonoBehaviour
{
    public GameObject obj;

    private float targetScale;
    public float maxScale = 10.0f;
    public float minScale = 2.0f;

    public float shrinkSpeed = 1.0f;
    public float shrinkSpeedTwo = -0.5f;

    private bool resizing = true;

    void Update()
    {
        if (resizing)
        {
                targetScale = minScale;
                //Resize();

            }

            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);

            //Debug.Log(obj.transform.localScale);

            if (obj.transform.localScale.x == targetScale)
            {
            resizing = false;
            Debug.Log(resizing);
            }
        }     
    }
