using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 directionalForce;
    private float timeToDirection;
    public float timeToDirectionSet = 1f;
    public float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        directionalForce = new Vector3(1, 0, 0);
        timeToDirection = timeToDirectionSet;
    }

    private void Update()
    {
        if (timeToDirection <= 0)
        {
            directionalForce *= -1;
            timeToDirection = timeToDirectionSet;
        }else if (timeToDirection >= 0)
        {
            timeToDirection -= Time.deltaTime;
        }
    }

    public void TakeDamageMe()
    {
        speed = speed / 2;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed * Time.deltaTime * directionalForce.x, rb.velocity.y, rb.velocity.z);
    }
}
