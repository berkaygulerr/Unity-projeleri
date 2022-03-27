using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    /// <summary>
    /// The lerp speed of the stat's content fill value
    /// </summary>
    [SerializeField]
    private float lerpSpeed; // value = 10

    /// <summary>
    /// The actual image that we are changing the fill of
    /// </summary>
    private Image content;

    /// <summary>
    /// Hold the current fill value
    /// </summary>
    private float currentFill;

    /// <summary>
    /// The property for setting the max value
    /// </summary>
    public float MyMaxValue { get; set; }

    /// <summary>
    /// The stat's current value
    /// </summary>
    private float currentValue;

    /// <summary>
    /// The property for setting the current value
    /// </summary>
    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
        }
    }

    private void Start()
    {
        content = GetComponent<Image>();
    }

    private void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, lerpSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// The function that adjusts the initial value of the player's health
    /// </summary>
    /// <param name="currentValue"></param>
    /// <param name="maxValue"></param>
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
