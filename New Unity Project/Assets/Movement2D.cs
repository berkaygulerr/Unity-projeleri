using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Components")] private Rigidbody2D rb2D;

    [Header("Layer Masks")] [SerializeField]
    private LayerMask groundLayer;
    
    [Header("Movement Variables")]
    [SerializeField] private float movementAcceleration = 50f;
    [SerializeField] private float maxMoveSpeed = 12f;
    [SerializeField] private float groundLinearDrag = 7f;
    private float horizontalDirection;

    private bool changingDirection => (rb2D.velocity.x > 0f && horizontalDirection < 0f) ||
                                      (rb2D.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Junp Variables")] [SerializeField]
    private float jumpForce = 12f;

    [SerializeField] private float airLinearDrag = 2.5f;

    private bool canJump => Input.GetButtonDown("Jump") && onGround;

    [Header("Ground Collision Variables")] [SerializeField]
    private float groundRaycastLength;

    [SerializeField] private bool onGround;

    private Animator anim;
    
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalDirection = GetInput().x;
        if (canJump) Jump();
    }

    private void FixedUpdate()
    {
        CheckCollisions();
        MoveCharacter();
        if (onGround)
            ApplyGroundLinearDrag();
        else
        {
            ApplyAirLinearDrag();
        }

        if (!Mathf.Approximately(0, horizontalDirection))
            transform.rotation = horizontalDirection < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        rb2D.AddForce(new Vector2(horizontalDirection, 0f) * movementAcceleration);

        if (Mathf.Abs(rb2D.velocity.x) > maxMoveSpeed)
            rb2D.velocity = new Vector2(Mathf.Sign(rb2D.velocity.x) * maxMoveSpeed, rb2D.velocity.y);
        
        anim.SetFloat("Speed", Mathf.Abs(horizontalDirection));
    }

    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(horizontalDirection) < 0.4f || changingDirection)
            rb2D.drag = groundLinearDrag;
        else
            rb2D.drag = 0f;
    }
    
    private void ApplyAirLinearDrag()
    {
        rb2D.drag = airLinearDrag;
    }
    
    private void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckCollisions()
    {
        onGround = Physics2D.Raycast(transform.position * groundRaycastLength, Vector2.down, groundRaycastLength,
            groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLength);
    }
}
