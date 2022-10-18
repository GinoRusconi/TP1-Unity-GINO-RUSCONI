using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    public GameObject[] canvas;
    private AudioSource soundButton;

    private void Awake()
    {
        soundButton = GetComponent<AudioSource>();
    }

    public void NextScene()
    {
        StartCoroutine(SceneLoaded(CurrentScene().buildIndex + 1, soundButton.clip != null ? soundButton.clip.length : 0));
    }

    public Scene CurrentScene()
    {
        return SceneManager.GetActiveScene();
    }

    public void ResetLevel()
    {
        StartCoroutine(SceneLoaded(GameManager.gameManager.previousScene, soundButton.clip.length));
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void GoMenuInicial()
    {
        StartCoroutine(SceneLoaded(0, soundButton.clip.length));
    }

    public void OpenCanvas(GameObject canvasToOpen)
    {
        foreach (var canvas in canvas)
        {
            if (canvas == canvasToOpen)
            {
                canvas.SetActive(true);
            }else
            {
                canvas.SetActive(false);
            }
        }
    }

    
    public void LoseGameScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void WinGameScene()
    {
        SceneManager.LoadScene("WinGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator SceneLoaded(int sceneIndex, float timeSound)
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(timeSound);
        SceneManager.LoadScene(sceneIndex);
    }
}
