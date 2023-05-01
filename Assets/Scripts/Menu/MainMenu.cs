using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelLoad;
    private int firstLevel = 4;

    public void NewGame()
    {
        GameManager.nextLevel = firstLevel;
        PlayerPrefs.SetInt("NextLevel", firstLevel);
        PlayerPrefs.SetInt("levelOpen", 4);
        SceneManager.LoadScene(firstLevel);
    }

    public void LoadGame()
    {
        levelLoad = PlayerPrefs.GetInt("NextLevel");
        if (levelLoad == 0)
        {

        } else {
            GameManager.nextLevel = levelLoad;
            SceneManager.LoadScene(levelLoad);
        }
    }

    public void LoadLevelsScene()
    {
        SceneManager.LoadScene(2);
    }

    public void CreditScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSkinsScene()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();;
    }
}