using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]
    private float speed;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2D.position += Vector2.right * Time.fixedDeltaTime * speed;
    }
}
