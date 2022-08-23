using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerNivel3 : MonoBehaviour
{
    TimeManager timemanager;
    Player player;
    public float timeToWin;
    public int NextLvl;
    bool _finishCurrentLevel=false;
    private void Awake()
    {
        GameObject timemanagerGO = GameObject.Find("TimeManager");
        timemanager = timemanagerGO.GetComponent<TimeManager>();
        GameObject playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Player>();
    }


    private void Update()
    {
        if (!_finishCurrentLevel)
        {
            if (timemanager.timeFromStart >= timeToWin)
            {
                CancelInvoke();
                Invoke("WinGame",2f);
                _finishCurrentLevel = true;
            }

            else if (!player.isPlayerHealth)
            {
                CancelInvoke();
                Invoke("LoseGame", 2f);
                _finishCurrentLevel = true;
            }
        }
    }

    private void LoseGame()
    {
        GameManager.gameManager.GameLose();
    }

    private void WinGame()
    {
        GameManager.gameManager.NextLevel();
    }
}

