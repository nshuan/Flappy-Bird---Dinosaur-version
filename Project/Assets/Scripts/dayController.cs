using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayController : MonoBehaviour
{
    public GameObject[] objectsWithBrightDefault;
    public GameObject[] objectsWithDarkDefault;
    public Text[] texts;

    private int gameTimeCounter = 0;
    private bool isNight = false;

    public int convertSpeed = 1;
    private int convertCounter = 0;

    public GameObject moon;
    public Sprite[] moonSprites;
    private int dayCounter = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!isNight) {
            if (gameTimeCounter < 1000) {
                gameTimeCounter += 1;
            }
            else {
                convertCounter += 1;
                if (convertCounter < 15) {
                    convertToNight();
                }
                else {
                    convertCounter = 0;
                    gameTimeCounter = 0;
                    isNight = true;
                    moon.SetActive(true);
                }
            }
        }
        else {
            if (gameTimeCounter < 400) {
                gameTimeCounter += 1;
            }
            else {
                convertCounter += 1;
                if (convertCounter < 15) {
                    convertToDay();
                }
                else {
                    convertCounter = 0;
                    gameTimeCounter = 0;
                    isNight = false;

                    moon.transform.position = new Vector2(7.0f, 6.5f + Random.Range(-1.0f, 0.5f));
                    moon.SetActive(false);
                    dayCounter += 1;
                    if (dayCounter > 6) dayCounter = 0;
                    moon.GetComponent<SpriteRenderer>().sprite = moonSprites[dayCounter];
                }
            }
        }
    }

    void convertToNight()
    {
        for (int i = 0; i < objectsWithBrightDefault.Length; i++) {
            SpriteRenderer sprite_renderer = objectsWithBrightDefault[i].GetComponent<SpriteRenderer>();
            Color _color = sprite_renderer.material.color;
            _color.r -= convertSpeed*0.05f;
            _color.g -= convertSpeed*0.05f;
            _color.b -= convertSpeed*0.05f;
            sprite_renderer.material.color = _color;
        }
        for (int i = 0; i < objectsWithDarkDefault.Length; i++) {
            SpriteRenderer sprite_renderer = objectsWithDarkDefault[i].GetComponent<SpriteRenderer>();
            Color _color = sprite_renderer.material.color;
            _color.r += convertSpeed*0.05f;
            _color.g += convertSpeed*0.05f;
            _color.b += convertSpeed*0.05f;
            sprite_renderer.material.color = _color;
        }
        for (int i = 0; i < texts.Length; i++) {
            Color _color = texts[i].color;
            _color.r += convertSpeed*0.05f;
            _color.g += convertSpeed*0.05f;
            _color.b += convertSpeed*0.05f;
            texts[i].color = _color;
        }
    }

    void convertToDay()
    {
        for (int i = 0; i < objectsWithDarkDefault.Length; i++) {
            SpriteRenderer sprite_renderer = objectsWithDarkDefault[i].GetComponent<SpriteRenderer>();
            Color _color = sprite_renderer.material.color;
            _color.r -= convertSpeed*0.05f;
            _color.g -= convertSpeed*0.05f;
            _color.b -= convertSpeed*0.05f;
            sprite_renderer.material.color = _color;
        }
        for (int i = 0; i < objectsWithBrightDefault.Length; i++) {
            SpriteRenderer sprite_renderer = objectsWithBrightDefault[i].GetComponent<SpriteRenderer>();
            Color _color = sprite_renderer.material.color;
            _color.r += convertSpeed*0.05f;
            _color.g += convertSpeed*0.05f;
            _color.b += convertSpeed*0.05f;
            sprite_renderer.material.color = _color;
        }
        for (int i = 0; i < texts.Length; i++) {
            Color _color = texts[i].color;
            _color.r -= convertSpeed*0.05f;
            _color.g -= convertSpeed*0.05f;
            _color.b -= convertSpeed*0.05f;
            texts[i].color = _color;
        }
    }
}
