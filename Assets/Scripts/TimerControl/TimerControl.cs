using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public int initialSeconds;
    public Text actualTimeText;

    public GameObject player;
    public GameObject loseEffect;

    private bool timerEnabled = true;
    public float actualTime;

    private string difficulty;

    void Start()
    {
        difficulty = PlayerPrefs.GetString("Difficulty", "Normal");
        if (difficulty == "Normal")
        {
            actualTime = 0;
        }
        else
        {
            actualTime = initialSeconds;
        }
    }

    void FixedUpdate()
    {
        if (timerEnabled)
        {
            if (difficulty == "Normal")
            {
                actualTime += Time.deltaTime;
            }
            else
            {
                actualTime -= Time.deltaTime;
                if (actualTime <= 0) 
                {
                    timerEnabled = false;
                    FindObjectOfType<AudioManager>().PlaySound("Lose");
                    StartCoroutine(GameManager.RestartLevelEffect(player, loseEffect));
                }
            }
            TimeSpan timer = TimeSpan.FromSeconds(actualTime);
            actualTimeText.text = timer.ToString(@"mm\:ss");
        }
    }

    public void DisableTimer()
    {
        timerEnabled = false;
    }
}