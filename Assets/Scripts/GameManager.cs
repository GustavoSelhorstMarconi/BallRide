using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int nextLevel = 3;

    public static GameManager instance; // Criado para poder criar um coroutine em um método static

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Pause.gamePaused)
        {
            Time.timeScale = 1f;
        }
        FindObjectOfType<AudioManager>().StopSound("Win");
    }

    public static IEnumerator RestartLevelEffect(GameObject other, GameObject loseEffect)
    {
        GameObject cloneLoseEffect = Instantiate(loseEffect, other.transform.position, Quaternion.identity);
        cloneLoseEffect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().material = other.GetComponent<Renderer>().material;
        Destroy(other);
        yield return new WaitForSeconds(0.5f);
        RestartLevel();
    }

    public static void FireBallRestartLevel(GameObject other, GameObject loseEffect)
    {
        instance.StartCoroutine(RestartLevelEffect(other, loseEffect));
    }

    static IEnumerator LaserRestartLevel(GameObject other, GameObject cutPlayer)
    {
        GameObject cloneCutPlayer = Instantiate(cutPlayer, other.transform.position, other.transform.rotation);
        Material playerMaterial = other.GetComponent<Renderer>().material;
        Vector3 playerVelocity = other.GetComponent<Rigidbody>().velocity;
        Transform upPartClone = cloneCutPlayer.transform.GetChild(0);
        Transform downPartClone = cloneCutPlayer.transform.GetChild(1);

        upPartClone.gameObject.GetComponent<Renderer>().material = playerMaterial;
        downPartClone.gameObject.GetComponent<Renderer>().material = playerMaterial;

        upPartClone.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(playerVelocity.x, playerVelocity.y, playerVelocity.z);
        downPartClone.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(playerVelocity.x, -playerVelocity.y, playerVelocity.z);

        Destroy(other);
        yield return new WaitForSeconds(1f);
        RestartLevel();
    }

    public static void CallLaserRestartLevel(GameObject other, GameObject cutPlayer)
    {
        instance.StartCoroutine(LaserRestartLevel(other, cutPlayer));
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
        FindObjectOfType<AudioManager>().StopSound("Win");
    }

    public static void UnlockNextLevel()
    {
        if (nextLevel < SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevel++;
        }
        else
        {
            nextLevel = SceneManager.sceneCountInBuildSettings - 1;
            PlayerPrefs.SetInt("gameCompleted", 1);
        }

        if (nextLevel > PlayerPrefs.GetInt("levelOpen"))
        {
            PlayerPrefs.SetInt("levelOpen", nextLevel);
        }

        PlayerPrefs.SetInt("NextLevel", nextLevel);
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene(0);
        if (Pause.gamePaused)
        {
            Time.timeScale = 1f;
        }
        FindObjectOfType<AudioManager>().StopSound("Win");
    }
}