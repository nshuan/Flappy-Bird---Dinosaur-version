using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    // Use the script of game controller
    public GameObject gameController;
    private GameControllerScript controller_script;

    // Store the component Rigidbody2D of this object
    private Rigidbody2D thisBird;
    private float gravityLevel;

    // Check if the bird is jumped and stop jumping till it reaches the max height (jumpStep)
    private int jumpStep = 0;
    private bool jumped = false;

    // Sound
    public AudioSource sound_jump;
    public AudioSource sound_die;
  
    void Start()
    {        
        controller_script = gameController.GetComponent<GameControllerScript>();

        thisBird = GetComponent<Rigidbody2D>();
        gravityLevel = thisBird.gravityScale;
    }

    void Update()
    {
        if (controller_script.gameState == 1) {
            if (Input.GetKeyDown("p")) {
                controller_script.pauseGame();
            }
        }

        if (controller_script.gameState != 3) {
            if (Input.GetButtonDown("Jump") && transform.position.y <= 7.5f) {
                if (!jumped) {
                    transform.Rotate(0.0f, 0.0f, 30.0f, Space.World);
                }

                // Reset gravity scale and falling speed (falling velocity)
                thisBird.gravityScale = gravityLevel;
                thisBird.velocity = new Vector2(thisBird.velocity.x, 0);
                
                jumpStep = 0;
                jumped = true;

                sound_jump.Play();
            }
            else if (Input.touchCount > 0 && transform.position.y <= 7.5f) {
                for (int i = 0; i < Input.touchCount; i++) {
                    Touch currenTouch = Input.GetTouch(i);
                    if (currenTouch.phase == TouchPhase.Began) {
                        if (!jumped) {
                            transform.Rotate(0.0f, 0.0f, 30.0f, Space.World);
                        }

                        // Reset gravity scale and falling speed (falling velocity)
                        thisBird.gravityScale = gravityLevel;
                        thisBird.velocity = new Vector2(thisBird.velocity.x, 0);
                        
                        jumpStep = 0;
                        jumped = true;

                        sound_jump.Play();
                    }
                }
            }
        }
    }

    void FixedUpdate() {
        if (jumped) {
            Jump();
            jumpStep += 1;
            if (jumpStep == 8) {
                jumpStep = 0;
                jumped = false;
                transform.Rotate(0.0f, 0.0f, -30.0f, Space.World);
            }
        }
    }

    // This function is called when a trigger is detected
    void OnTriggerEnter2D()
    {
        sound_die.Play();
        controller_script.endGame();
    }

    void Jump() {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
    }
}
