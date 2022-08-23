using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyManager enemyManager;
    Renderer _renderer;
    private void Awake()
    {
        GameObject _GOenemyManager = GameObject.Find("EnemyManager");
        enemyManager = _GOenemyManager.GetComponent<EnemyManager>();
        _renderer = GetComponent<Renderer>();
    }
    void Mori()
    {
        enemyManager.enemysDie++;
        Destroy(gameObject);
    }

    public void TakeDamageMe()
    {
        //Color.RGBToHSV(_renderer.material.color, out float H, out float S, out float V);
        //_renderer.material.color = Color.HSVToRGB(H , S, V - 0.25f);
    }
}
