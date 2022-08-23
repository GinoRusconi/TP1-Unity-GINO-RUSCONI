using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerNivel2 : MonoBehaviour
{
    public int killsToWin;
    public int NextLvl;
    EnemyManager enemymanager;
    Player player;
    bool _finishCurrentLevel = false;


    private void Awake()
    {
        GameObject enemymanagerGO = GameObject.Find("EnemyManager");
        enemymanager = enemymanagerGO.GetComponent<EnemyManager>();

        GameObject playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Player>();
    }
    private void Update()
    {
        if (!_finishCurrentLevel)
        {
            if (enemymanager.enemysDie >= killsToWin)
            {
                CancelInvoke();
                Invoke("WinGame", 2f);
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
