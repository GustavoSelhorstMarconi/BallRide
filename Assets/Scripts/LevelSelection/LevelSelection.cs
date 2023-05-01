using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        int levelOpen = PlayerPrefs.GetInt("levelOpen", 4);

        // int i = 1 to no level unlocked and i = 30 to all levels unlocked
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (i + 4 > levelOpen)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}