using UnityEngine;
using System.Collections;

public class DieController : MonoBehaviour
{
    public float growRate = 1.0f;

    void Grow()
    {
        transform.localScale = new Vector2(growRate * 0.2f, growRate * 0.2f);
    }

    void Update()
    {
        Grow();
    }
}
