using UnityEngine;

public class Player : Character
{
    /// <summary>
    /// The player's health object
    /// </summary>
    [SerializeField]
    private Stat health;

    /// <summary>
    /// The player's initial health value
    /// </summary>
    private float initHealth = 100;

    protected override void Start()
    {
        health.Initialize(initHealth, initHealth);
        base.Start();
    }

    protected override void Update()
    {
        GetInput();
        base.Update();
    }

    /// <summary>
    /// The player's input function
    /// </summary>
    public void GetInput()
    {
        // try to health system
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical);
    }
}
