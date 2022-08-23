using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxLife = 100;

    public int currentLife;

    private void Awake()
    {
        currentLife = maxLife;
    }

    private void Update()
    {
        if (currentLife < 0)
        {
            SendMessage("Mori");
        }
    }

    public void TakeDamage(int dmg)
    {
        currentLife -= dmg;
        SendMessage("TakeDamageMe");
    }

    public void TakeCure(int lifeCure)
    {
        if (currentLife <= maxLife)
        {
            currentLife = Mathf.Clamp(currentLife + lifeCure,0,maxLife);
            SendMessage("TakeDamageMe");
        }
    }
}
