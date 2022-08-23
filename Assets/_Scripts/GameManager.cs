using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject prefMenuPause;
    private GameObject _menuPause;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void OpenMenuPause()
    {
        if (_menuPause == null)
            _menuPause = Instantiate(prefMenuPause);
        if (_menuPause != null && _menuPause.activeSelf == false)
        {
            Time.timeScale = 0f;
            _menuPause.SetActive(true);
        }

    }

    public void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void GameLose()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GameWin()
    {
        SceneManager.LoadScene("WinGame");
    }

}
