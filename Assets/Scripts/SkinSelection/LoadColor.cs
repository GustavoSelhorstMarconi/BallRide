using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadColor : MonoBehaviour
{
    public Material[] materials;
    private Renderer rendererPlayer;

    void Start()
    {
        // Color color = new Color();
        // color.r = PlayerPrefs.GetFloat("redColor", 0.9529412f);
        // color.g = PlayerPrefs.GetFloat("greenColor");
        // color.b = PlayerPrefs.GetFloat("blueColor");
        // rendererPlayer.material.color = color;
        rendererPlayer = GetComponent<Renderer>();
        int selectedColor = PlayerPrefs.GetInt("selectedMaterial");
        Material materialSelected = materials[selectedColor];
        rendererPlayer.material = materialSelected;
    }
}