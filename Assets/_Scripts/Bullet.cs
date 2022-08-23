using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public int damage;
    //[HideInInspector]
    public string tagToDamage;
    public float timeLifeDurationBullet;

    private void Awake()
    {
        damage = 20;
        Invoke("AutoDestruccion", timeLifeDurationBullet);
    }
    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
    }

    void AutoDestruccion()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void DobleDamage()
    {
        damage *= 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToDamage))
        {
            other.gameObject.GetComponent<Life>().TakeDamage(damage);
        }
        if (other.gameObject.CompareTag("Wall") && other.gameObject.TryGetComponent<Life>(out Life lifeComponent))
        {
            lifeComponent.TakeDamage(damage);
        }
        if (other.gameObject.CompareTag(tagToDamage) || other.gameObject.CompareTag("Wall"))
        {
            AutoDestruccion();
        }
    }
}
