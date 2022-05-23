using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float angularSpeed = 200;

    private Vector2 movement;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        // Move forward/backword with the given speed
        Vector3 direction = (transform.forward * movement.y).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void Turn()
    {
        // Turn clockwise/counterclockwise with the given angular speed
        float turn = movement.x  * Time.fixedDeltaTime * angularSpeed;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
