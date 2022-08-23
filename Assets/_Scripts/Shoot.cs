using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
    public Transform positionBullet;
    public float timeBetweenShootSet = 1f;
    public string tagToDamage;
    private bool dobleDamage = false;
    private float timeBetweenShoot;
    private AudioSource shootSound;
    private void Awake()
    {
        timeBetweenShoot = timeBetweenShootSet;
        shootSound = GetComponent<AudioSource>();
    }

    public void DoubleDamagePowerUp()
    {
        dobleDamage = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && timeBetweenShoot <= 0)
        {
            GameObject bulletPrefab = Instantiate(prefab, positionBullet.transform.position, positionBullet.rotation);
            bulletPrefab.GetComponentInChildren<Bullet>().tagToDamage = tagToDamage;
            shootSound.Play();
            if (dobleDamage)
            {
                bulletPrefab.GetComponentInChildren<Bullet>().DobleDamage();
            }
            timeBetweenShoot = timeBetweenShootSet;
        }
        else if(timeBetweenShoot >= 0)
        {
            timeBetweenShoot -= Time.deltaTime;
        }

    }
}
