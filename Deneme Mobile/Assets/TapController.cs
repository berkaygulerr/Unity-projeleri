using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float forceAmount = 5;
    private float defaultGravityScale = 1.5f;

    void Start()
    {
        rb2D.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.gravityScale = defaultGravityScale;

            if (rb2D.gravityScale != 0)
                AddForce();
        }
    }

    private void AddForce()
    {
        rb2D.velocity = Vector2.up * forceAmount;
    }
}
