using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject gameController;
    private GameControllerScript gameController_script;

    // Store the moving speed of background
    private int speed;

    // Store the default position
    private float default_position_x = 27.0f;

    void Start()
    {
        gameController_script = gameController.GetComponent<GameControllerScript>();
        speed = gameController_script.backgroundSpeed;
    }

    void FixedUpdate()
    {
        if (gameController_script.gameState == 1) {
            speed = gameController_script.backgroundSpeed;
            transform.position = new Vector2(transform.position.x - speed*0.025f, transform.position.y);
            if (transform.position.x <= default_position_x - 2*21.5f) {
                transform.position = new Vector2(default_position_x, transform.position.y);
            }
        }
    }
}
