using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatSelection : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedSkin = 0;
    public GameObject iconSelection;

    public void Start()
    {
        VerifyIconSelection();
    }

    public void NextSkin()
    {
        skins[selectedSkin].SetActive(false);
        selectedSkin = selectedSkin + 1 < skins.Length ? selectedSkin + 1 : 0;
        skins[selectedSkin].SetActive(true);
        VerifyIconSelection();
    }

    public void PreviousSkin()
    {
        skins[selectedSkin].SetActive(false);
        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin += skins.Length;
        }
        skins[selectedSkin].SetActive(true);
        VerifyIconSelection();
    }

    public void LoadHatSelection()
    {
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
        VerifyIconSelection();
    }

    private void VerifyIconSelection()
    {
        if(selectedSkin == PlayerPrefs.GetInt("selectedSkin", 0))
        {
            iconSelection.SetActive(true);
        }
        else
        {
            iconSelection.SetActive(false);
        }
    }
}
