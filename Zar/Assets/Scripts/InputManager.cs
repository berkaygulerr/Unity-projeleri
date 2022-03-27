using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public delegate void InputHandler();
    public static event InputHandler OnAddPersons;

    GameManager gameManager;

    public InputField inputPersonCount;
    public InputField inputPersonName;

    InputField[] inputPersonNames;

    public GameObject nameInputs;
    public GameObject okayButtonPrefab;

    private int personCount;
    public int PersonCount
    {
        get { return personCount; }

        private set
        {
            if (value < 0)
                personCount = 0;
            else if (value > 8)
                personCount = 8;
            else
                personCount = value;
        }
    }
    public bool IsSubmit => Input.GetButtonDown("Submit") && inputPersonCount.text != "";

    public static string[] PersonNames { get; set; }

    bool okayButtonActive = false;

    void Start()
    {
        gameManager = GameManager.Instance;
        nameInputs.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.OnLoadMainMenu += GameManager_OnLoadMainMenu;
    }

    private void OnDisable()
    {
        GameManager.OnLoadMainMenu -= GameManager_OnLoadMainMenu;
    }

    private void GameManager_OnLoadMainMenu()
    {
        SavePersonNames();
        gameManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (IsSubmit)
            CreateInputName(inputPersonCount);

        InputNamesControl();
    }

    private void CreateInputName(InputField inputField)
    {
        ClearAllInputName();

        PersonCount = int.Parse(inputField.text);

        inputPersonNames = new InputField[PersonCount];

        nameInputs.SetActive(true);
        for (int i = 0; i < inputPersonNames.Length; i++)
        {
            inputPersonNames[i] = Instantiate(inputPersonName, Vector2.zero, Quaternion.identity, nameInputs.transform);
        }
        OnAddPersons();
    }

    private void ClearAllInputName()
    {
        int nameInputCount = nameInputs.transform.childCount;
        if (nameInputCount > 0)
        {
            for (int i = 0; i < nameInputCount; i++)
                Destroy(nameInputs.transform.GetChild(i).gameObject);
        }
    }

    private void InputNamesControl()
    {
        if (inputPersonNames != null)
        {
            for (int i = 0; i < inputPersonNames.Length; i++)
            {
                if (inputPersonNames[i].text != "")
                    okayButtonActive = true;
                else
                {
                    okayButtonActive = false;
                    break;
                }
            }

            if (gameManager.okayButton != null)
            {
                if (okayButtonActive)
                    gameManager.okayButton.interactable = true;
                else
                    gameManager.okayButton.interactable = false;
            }
        }
    }
    private void SavePersonNames()
    {
        PersonNames = new string[PersonCount];

        for (int i = 0; i < PersonNames.Length; i++)
        {
            PersonNames[i] = inputPersonNames[i].text;
        }
    }
}
