using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public delegate void DiceHandler();
    public static event DiceHandler OnTwoDiceRolled;

    public int DiceNo { get; set; }

    GameManager gameManager;

    public Sprite[] diceSprites;
    Image content;

    private void Start()
    {
        gameManager = GameManager.Instance;
        content = GetComponent<Image>();
    }

    private void OnEnable()
    {
        GameManager.OnRollDice += GameManager_OnRollDice;
    }

    private void OnDisable()
    {
        GameManager.OnRollDice -= GameManager_OnRollDice;
    }

    private void GameManager_OnRollDice()
    {
        gameManager.diceInfoText.text = "";
        gameManager.rollButton.interactable = false;
        gameManager.infoText.text = "Zar atılıyor";
        content.color = new Color(1, 1, 1, 0.5f);

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        for (int i = 0; i < diceSprites.Length; i++)
        {
            int cd = Random.Range(0, 6);
            content.sprite = diceSprites[cd];

            gameManager.infoText.text += ".";

            if (i == 3)
                gameManager.infoText.text = "Zar atılıyor";

            DiceNo = cd + 1;

            yield return new WaitForSeconds(0.3f);
        }

        content.color = Color.white;
        gameManager.rollButton.interactable = true;
        gameManager.infoText.text = "";

        if (SceneManager.GetActiveScene().name == "TwoDice")
            OnTwoDiceRolled();
        else
            gameManager.diceInfoText.text = DiceNo.ToString();
    }
}
