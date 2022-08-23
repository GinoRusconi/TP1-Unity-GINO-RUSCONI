using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isPlayerHealth = true;
    public ParticleSystem deadPlayerParticle;
    public Image _lifeFilled;
    Renderer _renderer;
    Life _life;
    Shoot _shoot;
    MovimientoPlayer _movimientoPlayer;
    private void Awake()
    {
        //_renderer = GetComponent<Renderer>();
        _life = GetComponent<Life>();
        _shoot = GetComponent<Shoot>();
        _movimientoPlayer = GetComponent<MovimientoPlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.gameManager.OpenMenuPause();
        }
    }
    public void DobleDamage()
    {
        _shoot.DoubleDamagePowerUp();
    }
    public void Cure(int lifeCure)
    {
        _life.TakeCure(lifeCure);
    }

    public void SpeedUp(float value)
    {
        _movimientoPlayer.movementSpeed += value;
    }
    void Mori()
    {
        isPlayerHealth = false;
        Instantiate(deadPlayerParticle,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    public void TakeDamageMe()
    {
        float porcentaje = (float)_life.currentLife / _life.maxLife;
        _lifeFilled.fillAmount = porcentaje;
    }
    
}
