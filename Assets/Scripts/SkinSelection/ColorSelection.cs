using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    public Material[] materials;
    public GameObject player;
    public int selectedMaterial;
    public GameObject iconSelection;

    private Renderer rendererPlayer;

    void Start()
    {
        rendererPlayer = player.GetComponent<Renderer>();
        rendererPlayer.material = materials[0];
        VerifyIconSelection();
    }

    public void NextColor()
    {
        selectedMaterial = selectedMaterial + 1 < materials.Length ? selectedMaterial + 1 : 0;
        rendererPlayer.material = materials[selectedMaterial];
        VerifyIconSelection();
    }

    public void PreviousColor()
    {
        selectedMaterial--;
        if (selectedMaterial < 0)
        {
            selectedMaterial += materials.Length;
        }
        rendererPlayer.material = materials[selectedMaterial];
        VerifyIconSelection();
    }

    public void LoadColorSelection()
    {
        PlayerPrefs.SetInt("selectedMaterial", selectedMaterial);
        VerifyIconSelection();
        // PlayerPrefs.SetFloat("redColor", materials[selectedMaterial].r);
        // PlayerPrefs.SetFloat("greenColor", materials[selectedMaterial].g);
        // PlayerPrefs.SetFloat("blueColor", materials[selectedMaterial].b);
    }

    private void VerifyIconSelection()
    {
        if(selectedMaterial == materials.Length - 1 && PlayerPrefs.GetInt("gameCompleted", 0) == 0)
        {
            iconSelection.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            iconSelection.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }
        if(selectedMaterial == PlayerPrefs.GetInt("selectedMaterial", 0))
        {
            iconSelection.SetActive(true);
        }
        else
        {
            iconSelection.SetActive(false);
        }
    }
}