using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutamaticShoot : MonoBehaviour
{
    public GameObject prefab;
    public Transform positionBullet;
    public float timeStartShoot;
    public float timeRepeatRateShoot;
    public string tagToDamage;
    private AudioSource shootSound;

    private void Awake()
    {
        InvokeRepeating("Shoot", timeStartShoot, timeRepeatRateShoot);
        shootSound = GetComponent<AudioSource>();
    }

    private void Shoot()
    {
        GameObject bulletPrefab = Instantiate(prefab, positionBullet.transform.position, positionBullet.rotation);
        bulletPrefab.GetComponentInChildren<Bullet>().tagToDamage = tagToDamage;
        shootSound.Play();
    }
}
