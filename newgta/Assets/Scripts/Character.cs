using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character : MonoBehaviour
{
    /// <summary>
    /// The character's movement speed
    /// </summary>
    [SerializeField]
    private float speed; // value = 4

    /// <summary>
    /// The character's vertical movement value
    /// </summary>
    protected float vertical;

    /// <summary>
    /// The character's horizontal movement value
    /// </summary>
    protected float horizontal;

    /// <summary>
    /// The character's movement vector value
    /// </summary>
    protected Vector2 direction;

    /// <summary>
    /// The character's RigidBody2D reference
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// The character's Animator reference
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Whether the character is in movement or not
    /// </summary>
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
      
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// The character's movement function
    /// </summary>
    public void Move()
    {
        rb.velocity = direction.normalized * speed;
    }

    /// <summary>
    /// The function that handling animation layers
    /// </summary>
    public void HandleLayers()
    {
        if (IsMoving)
        {
            // set the weight of the WalkLayer to 1
            ActivateLayer("WalkLayer");

            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);
        }
        else
        {
            // set the weight of the IdleLayer to 1
            ActivateLayer("IdleLayer");
        }
    }

    /// <summary>
    /// The function that activate animator layer
    /// </summary>
    /// <param name="layerName"></param>
    public void ActivateLayer(string layerName)
    {
        // All the animator layers set to weight 0
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        // layerName is set to 1 weight
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }
}
