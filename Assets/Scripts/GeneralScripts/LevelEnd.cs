using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject timerControl;
    public GameObject endPanel;

    [Header("Time to unlock stars")]
    public int secondsSecondStar;
    public int secondsThirtStar;
    private List<GameObject> stars;

    private GameObject backToMenuButton;
    private GameObject buttonJump;
    private GameObject buttonRestart;
    private GameObject joystick;

    void Start()
    {
        stars = new List<GameObject>();
        for (int i = 0; i < endPanel.transform.childCount; i++)
        {
            stars.Add(endPanel.transform.GetChild(i).gameObject);
        }

        backToMenuButton = endPanel.transform.parent.transform.Find("BackToMenuButton").gameObject;
        buttonJump = endPanel.transform.parent.transform.Find("ButtonJump").gameObject;
        buttonRestart = endPanel.transform.parent.transform.Find("ButtonRestart").gameObject;
        joystick = endPanel.transform.parent.transform.Find("Fixed Joystick").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Win");
            GameManager.UnlockNextLevel();
            EnterReplayMode(other.gameObject);
        }
    }

    private void EnterReplayMode(GameObject player)
    {
        if (PlayerPrefs.GetString("Difficulty", "Normal") == "Normal")
        {
            player.GetComponent<ActReplay>().ChangeReplayMode();
            timerControl.GetComponent<TimerControl>().DisableTimer();
            StarActive();
            backToMenuButton.SetActive(false);
            buttonJump.SetActive(false);
            buttonRestart.SetActive(false);
            joystick.SetActive(false);
        }
        else
        {
            GameManager.NextLevel();
        }
    }

    private void StarActive()
    {
        endPanel.SetActive(true);
        float actualTime = timerControl.GetComponent<TimerControl>().actualTime;
        if (actualTime < secondsThirtStar)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (actualTime < secondsSecondStar)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
    }
}