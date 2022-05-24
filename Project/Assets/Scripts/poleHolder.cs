using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleHolder : MonoBehaviour
{
    // Use the script of game controller to add score
    private GameControllerScript controller_script;
    private bool addedScore = false;

    // Store the prefab of poles to instantiate
    public GameObject Pole_highPrefab;
    public GameObject Pole_lowPrefab;

    private int poleSpeed;

    void Start()
    {
        controller_script = GetComponentInParent<GameControllerScript>();
        poleSpeed = controller_script.poleSpeed;

        int choose_pole = Random.Range(0, 3);
        switch (choose_pole) {
            case 0: {
                Instantiate(Pole_highPrefab).transform.parent = transform;
                break;
            }
            case 1: {
                Instantiate(Pole_lowPrefab).transform.parent = transform;
                break;
            }
            case 2: {
                Instantiate(Pole_highPrefab).transform.parent = transform;
                Instantiate(Pole_lowPrefab).transform.parent = transform;
                break;
            }
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(0f, 5.0f));
    }

    void Update()
    {
        if (transform.position.x <= -2.0f && !addedScore) {
            controller_script.Score += 1;
            addedScore = true;
        }
    }

    void FixedUpdate()
    {
        poleSpeed = controller_script.poleSpeed;
        transform.position = new Vector2(transform.position.x - poleSpeed*0.05f, transform.position.y);
        if (transform.position.x <= -8.0f) Destroy(gameObject);
    }
}
