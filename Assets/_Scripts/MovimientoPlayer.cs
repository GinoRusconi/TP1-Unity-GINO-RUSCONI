using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    private Vector3 movementDirection;
    
    private Rigidbody rb;

    public float movementSpeed;
    public float maxSpeed;

    private void Awake()
    {
          rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementZ = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector3(movementX,0,movementZ);
    }

    private void FixedUpdate()
    {
        Vector3 force = Vector3.ClampMagnitude(movementSpeed * Time.deltaTime * movementDirection, maxSpeed);
        rb.AddForce(force);
    }

}
