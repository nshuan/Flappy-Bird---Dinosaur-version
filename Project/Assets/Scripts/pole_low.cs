using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pole_low : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector2(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-2.0f, 0.5f));
    }
}
