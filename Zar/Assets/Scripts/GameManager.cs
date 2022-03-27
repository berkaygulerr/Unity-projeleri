using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            instance = FindObjectOfType<GameManager>();
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }

            return instance;
        }
    }

    public delegate void GameHandler();
    public static event GameHandler OnRollDice;
    public static event GameHandler OnLoadMainMenu;

    public bool OnDiceScenes => SceneManager.GetActiveScene().name == "OneDice" || SceneManager.GetActiveScene().name == "TwoDice";
    public bool OnMainOrOneDiceScene => SceneManager.GetActiveScene().name == "OneDice" || SceneManager.GetActiveScene().name == "MainMenu";
    public bool OnMainOrTwoDiceScene => SceneManager.GetActiveScene().name == "TwoDice"  || SceneManager.GetActiveScene().name == "MainMenu";

    [HideInInspector] public Text infoText;
    [HideInInspector] public Text diceInfoText;
    [HideInInspector] public Button rollButton;
    [HideInInspector] public Button okayButton;
    private Button mainMenu;
    private Button oneDiceButton;
    private Button twoDiceButton;
    private Dice[] dices;

    InputManager inputManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        inputManager = FindObjectOfType<InputManager>();

        SetButtons();
        SetDices();
    }

    private void OnEnable()
    {
        Dice.OnTwoDiceRolled += Dice_OnTwoDiceRolled;
        InputManager.OnAddPersons += InputManager_OnAddPersons;
    }

    private void OnDisable()
    {
        Dice.OnTwoDiceRolled -= Dice_OnTwoDiceRolled;
        InputManager.OnAddPersons -= InputManager_OnAddPersons;
    }

    private void InputManager_OnAddPersons()
    {
        // okay button game object
        GameObject okayButtonGo = Instantiate(inputManager.okayButtonPrefab, Vector2.zero, Quaternion.identity, inputManager.nameInputs.transform);
        okayButton = okayButtonGo.GetComponent<Button>();
        okayButton.onClick.AddListener(() => OnLoadMainMenu());
    }

    private void Dice_OnTwoDiceRolled()
    {
        int total = 0;

        for (int i = 0; i < dices.Length; i++)
        {
            total += dices[i].DiceNo;
        }

        diceInfoText.text = total.ToString();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void SetButtons()
    {
        if (OnDiceScenes)
        {
            rollButton = GameObject.Find("RollDice").GetComponent<Button>();
            rollButton.onClick.AddListener(() => OnRollDice());

            infoText = GameObject.Find("Info").GetComponent<Text>();
            infoText.text = "Zar atınız";

            diceInfoText = GameObject.Find("DiceInfo").GetComponent<Text>();

            mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
            mainMenu.onClick.AddListener(() => LoadScene("MainMenu"));
        }

        if (OnMainOrOneDiceScene)
        {
            twoDiceButton = GameObject.Find("ÇiftZar").GetComponent<Button>();
            twoDiceButton.onClick.AddListener(() => LoadScene("TwoDice"));
        }

        if (OnMainOrTwoDiceScene)
        {
            oneDiceButton = GameObject.Find("TekZar").GetComponent<Button>();
            oneDiceButton.onClick.AddListener(() => LoadScene("OneDice"));
        }
    }

    void SetDices()
    {
        if (SceneManager.GetActiveScene().name == "TwoDice")
        {
            dices = FindObjectsOfType<Dice>();
        }
    }
}
