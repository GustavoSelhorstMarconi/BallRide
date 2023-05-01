using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficulty : MonoBehaviour
{
    public GameObject difficultySelection;
    private GameObject selectedIcon;

    void Start()
    {
        selectedIcon = difficultySelection.transform.GetChild(0).gameObject;
        selectedIcon.SetActive(PlayerPrefs.GetString("Difficulty") == "Speed");
    }

    public void SelectionDifficultyBox()
    {
        if (selectedIcon.activeSelf)
        {
            selectedIcon.SetActive(false);
            PlayerPrefs.SetString("Difficulty", "Normal");
            FindObjectOfType<AudioManager>().StopSound("ThemeSongSpeedMode");
            FindObjectOfType<AudioManager>().PlaySound("ThemeSong");
        }
        else if (!selectedIcon.activeSelf)
        {
            selectedIcon.SetActive(true);
            PlayerPrefs.SetString("Difficulty", "Speed");
            FindObjectOfType<AudioManager>().StopSound("ThemeSong");
            FindObjectOfType<AudioManager>().PlaySound("ThemeSongSpeedMode");
        }
    }
}