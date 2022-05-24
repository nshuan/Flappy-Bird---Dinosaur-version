using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour
{
    public int moonSpeed = 2;
    void Start()
    {
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - moonSpeed*0.015f, transform.position.y);
    }
}
