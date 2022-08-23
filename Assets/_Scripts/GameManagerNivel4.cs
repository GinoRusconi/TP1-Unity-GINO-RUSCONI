using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerNivel4 : MonoBehaviour
{
    public int killsToWin;
    public int NextLvl;
    public float timeToWin;
    EnemyManager enemymanager;
    Player player;
    TimeManager timemanager;
    bool _finishCurrentLevel = false;
    private void Awake()
    {
        GameObject enemymanagerGO = GameObject.Find("EnemyManager");
        enemymanager = enemymanagerGO.GetComponent<EnemyManager>();

        GameObject timemanagerGO = GameObject.Find("TimeManager");
        timemanager = timemanagerGO.GetComponent<TimeManager>();

        GameObject playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Player>();
    }
    private void Update()
    {
        if (!_finishCurrentLevel)
        {
            if (enemymanager.enemysDie >= killsToWin)
            {
                if (timemanager.timeFromStart >= timeToWin)
                {
                    CancelInvoke();
                    Invoke("WinGame", 2f);
                    _finishCurrentLevel = true;
                }
            }
            else if (!player.isPlayerHealth)
            {
                CancelInvoke();
                Invoke("LoseGame", 2f);
                _finishCurrentLevel = true;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void LoseGame()
    {
        GameManager.gameManager.GameLose();
    }

    private void WinGame()
    {
        GameManager.gameManager.GameWin();
    }
}
