using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUps _myPowerUP;
    public int value;
    public enum PowerUps
    {
        Life,
        Damage,
        Speed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (_myPowerUP)
            {
                case PowerUps.Life:
                    other.GetComponent<Player>().Cure(value);
                    break;
                case PowerUps.Damage:
                    other.GetComponent<Player>().DobleDamage();
                    break;
                case PowerUps.Speed:
                    other.GetComponent<Player>().SpeedUp(value);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
