using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject pauseNote;
    Text pauseNoteText;

    // Store pole holder to Instantiate after a period
    public GameObject poleHolder;
    private int counter = 0;

    // Save player's score
    public GameObject ScoreText;
    private Text ScoreTextComponent;
    public int Score = 0;

    // Speed of pole holder
    public int poleGenerateSpeed = 2;
    public int poleSpeed = 2;

    // Store the speed of background
    public int backgroundSpeed = 2;
    
    // Level bounder to control the speed of the game
    private int[] levelBounder = {0, 50, 100, 200, 350, 500, 10000};

    // Check if the game is paused (true in the beginning of the game)
    public int gameState;

    public GameObject gameOverText;

    public AudioSource sound_point;
    private bool sound_point_played = false;
    
    void Start()
    {
        ScoreTextComponent = ScoreText.GetComponent<Text>();
        
        pauseGame();
        gameState = 0;   
        
        pauseNoteText = pauseNote.GetComponent<Text>();
        pauseNoteText.text = "Tap to play!";
    }

    void Update()
    {
        if (gameState == 0) {
            if (Input.GetButtonDown("Jump")) {
                resumeGame();
            }
            else if (Input.touchCount > 0) {
                for (int i = 0; i < Input.touchCount; i++) {
                    Touch currenTouch = Input.GetTouch(i);
                    if (currenTouch.phase == TouchPhase.Began)
                        resumeGame();
                }
            }
        }

        else if (gameState == 2) {
            pauseNoteText.text = "Paused.\n\nTap to continue!";

            if (Input.GetButtonDown("Jump")) {
                resumeGame();
            }
            else if (Input.touchCount > 0) {
                for (int i = 0; i < Input.touchCount; i++) {
                    Touch currenTouch = Input.GetTouch(i);
                    if (currenTouch.phase == TouchPhase.Began)
                        resumeGame();
                }
            }
        }
        else if (gameState == 1) {
            if (Input.GetKeyDown("p")) {
                pauseGame();
            }
            ScoreTextComponent.text = "Score: " + Score.ToString();

            if (Score % 50 == 0 && Score != 0 && !sound_point_played) {
                sound_point.Play();
                sound_point_played = true;
            }
            else if (Score % 50 == 1) sound_point_played = false;
        }
        else if (gameState == 3) {
            pauseNoteText.text = "Tap to restart!";

            if (Input.GetButtonDown("Jump")) {
                restartGame();
            }
            else if (Input.touchCount > 0) {
                for (int i = 0; i < Input.touchCount; i++) {
                    Touch currenTouch = Input.GetTouch(i);
                    if (currenTouch.phase == TouchPhase.Began)
                        restartGame();
                }
            }
        }

        // Set new speed for the game each time the player reach high score
        for (int i = 1; i < levelBounder.Length; i++) {
            if (levelBounder[i-1] <= Score && Score < levelBounder[i]) {
                if (poleSpeed < i + 1) {
                    poleGenerateSpeed = i + 1;
                    poleSpeed = i + 1;
                    backgroundSpeed = i + 1;
                }
            }
        }
    }

    void FixedUpdate()
    {
        counter += 1;
        if (counter == 100/poleGenerateSpeed) {
            Instantiate(poleHolder).transform.parent = transform;
            counter = 0;
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        gameState = 2;

        pauseNote.SetActive(true);
        ScoreText.SetActive(false);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        gameState = 1;

        pauseNote.SetActive(false);
        ScoreText.SetActive(true);
    }

    public void endGame()
    {
        pauseNote.SetActive(true);
        gameOverText.SetActive(true);
        
        Time.timeScale = 0;
        gameState = 3;
    }

    void restartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
