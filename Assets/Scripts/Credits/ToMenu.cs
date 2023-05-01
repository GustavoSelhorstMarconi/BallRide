using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreditSequence());
    }

    private IEnumerator CreditSequence()
    {
        yield return new WaitForSeconds(16);
        SceneManager.LoadScene(0);
    }
}