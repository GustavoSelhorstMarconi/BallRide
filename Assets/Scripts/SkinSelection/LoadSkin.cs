using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkin : MonoBehaviour
{
    public GameObject[] skinsPrefabs;
    public Transform player;
    public Vector3[] offset;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty", "Normal") == "Normal")
        {
            int selectedSkin = PlayerPrefs.GetInt("selectedSkin");
            GameObject prefabSkin = skinsPrefabs[selectedSkin];
            if (!prefabSkin.CompareTag("Player"))
            {
                GameObject clone = Instantiate(prefabSkin, Vector3.zero, Quaternion.identity);
                clone.transform.SetParent(player, false);
                clone.transform.position = player.position + offset[selectedSkin];
            }
        }
        else
        {
            player.GetChild(3).gameObject.SetActive(true);
        }
    }
}