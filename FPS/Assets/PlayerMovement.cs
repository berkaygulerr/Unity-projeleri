using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    private float vertical, horizontal;
    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MoveInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        moveDir = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
        rb.position += (moveDir * speed) * Time.fixedDeltaTime;
    }
}
