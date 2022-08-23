using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCannon : MonoBehaviour
{
    Player player;
    public GameObject prefabBullet;
    public Transform bulletOutPosition;
    public bool iCanShoot= false;
    public string tagToDamage;
    public GameObject cannon;
    Renderer _renderer;
    Renderer renderSetStart;
    public float timeToShootSet= 1f;
    float timeToShoot;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        _renderer = cannon.GetComponent<Renderer>();
        renderSetStart = _renderer;
        _renderer.material.color = Color.white;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward,targetDirection, Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    

        if (timeToShoot >= timeToShootSet)
        {
            GameObject bulletPrefab =Instantiate(prefabBullet, bulletOutPosition.transform.position, bulletOutPosition.rotation);
            bulletPrefab.GetComponentInChildren<Bullet>().tagToDamage = tagToDamage;
            _renderer = renderSetStart;
            timeToShoot = 0;
        }
        else
        {
            timeToShoot += Time.deltaTime;
            _renderer.material.color = Color.Lerp(Color.white, Color.red, timeToShoot);

        }
    }

}
