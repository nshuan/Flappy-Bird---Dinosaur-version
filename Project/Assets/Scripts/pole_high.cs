using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pole_high : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector2(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-0.5f, 2.0f));
    }
}
