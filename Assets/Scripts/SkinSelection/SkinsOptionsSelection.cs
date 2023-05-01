using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinsOptionsSelection : MonoBehaviour
{
    [Header("Options skins:")]
    public GameObject[] options;
    [Header("Configuration skins:")]
    public GameObject[] configurations;

    public int selectedOption;

    public void NextOption()
    {
        options[selectedOption].SetActive(false);
        configurations[selectedOption].SetActive(false);

        selectedOption = selectedOption + 1 < options.Length ? selectedOption + 1 : 0;

        options[selectedOption].SetActive(true);
        configurations[selectedOption].SetActive(true);
    }

    public void PreviousOption()
    {
        options[selectedOption].SetActive(false);
        configurations[selectedOption].SetActive(false);

        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption += options.Length;
        }

        options[selectedOption].SetActive(true);
        configurations[selectedOption].SetActive(true);
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(2);
    }
}
