using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScreen : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        GameManager.nextLevel = level;
        SceneManager.LoadScene(level);
    }

    public void BackToMenu()
    {
        GameManager.BackToMenu();
    }
}
