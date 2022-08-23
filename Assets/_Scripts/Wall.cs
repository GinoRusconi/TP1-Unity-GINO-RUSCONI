using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Renderer _renderer;
    Life _life;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _life = GetComponent<Life>();
    }
    public void Mori()
    {
        Destroy(gameObject);
    }

    public void TakeDamageMe()
    {
        Color.RGBToHSV(_renderer.material.color, out float H, out float S, out float V);
        float porcentaje = (float)_life.currentLife / _life.maxLife;
        V = porcentaje;
        _renderer.material.color = Color.HSVToRGB(H, S, V);
    }
}
