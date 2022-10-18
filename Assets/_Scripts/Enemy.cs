using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    EnemyManager enemyManager;
    Life _life;
    public Image _lifeFilled;
    private void Awake()
    {
        GameObject _GOenemyManager = GameObject.Find("EnemyManager");
        enemyManager = _GOenemyManager.GetComponent<EnemyManager>();
        _life = GetComponent<Life>();
    }
    void Mori()
    {
        enemyManager.enemysDie++;
        Destroy(gameObject);
    }

    public void TakeDamageMe()
    {
        float porcentaje = (float)_life.currentLife / _life.maxLife;
        _lifeFilled.fillAmount = porcentaje;
    }
}
