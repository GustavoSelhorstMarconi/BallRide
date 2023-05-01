using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gamePaused;

    private GameObject pauseMenuPanel;
    private GameObject joystick;
    private GameObject pauseButton;
    private GameObject buttonJump;
    private GameObject buttonRestart;

    void Start()
    {
        pauseMenuPanel = transform.Find("PausePanel").gameObject;

        joystick = transform.Find("Fixed Joystick").gameObject;
        pauseButton = transform.Find("BackToMenuButton").gameObject;
        buttonJump = transform.Find("ButtonJump").gameObject;
        buttonRestart = transform.Find("ButtonRestart").gameObject;
    }

    // void Update()
    // {
    //     if (gamePaused)
    //     {
    //         Continue();
    //     }
    //     else
    //     {
    //         PauseLevel();
    //     }
    // }

    public void Continue()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        EnableControlPanel();
    }

    public void PauseLevel()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        DisableControlPanel();
    }

    void EnableControlPanel()
    {
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        buttonJump.SetActive(true);
        buttonRestart.SetActive(true);
    }

    void DisableControlPanel()
    {
        joystick.SetActive(false);
        pauseButton.SetActive(false);
        buttonJump.SetActive(false);
        buttonRestart.SetActive(false);
    }
}
