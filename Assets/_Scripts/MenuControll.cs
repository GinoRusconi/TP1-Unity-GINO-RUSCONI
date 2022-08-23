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
        SceneManager.LoadSceneAsync(CurrentScene().buildIndex + 1);
    }

    public Scene CurrentScene()
    {
        return SceneManager.GetActiveScene();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(CurrentScene().buildIndex);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void GoMenuInicial()
    {
        SceneManager.LoadScene(0);
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
}
