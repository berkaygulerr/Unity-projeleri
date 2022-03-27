using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SignManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text placeHolder;
    string placeHolderText;

    private void Start()
    {
        placeHolderText = placeHolder.text;
    }

    public void Submit()
    {
        if (nameInput.text != "")
        {
            GameManager.Instance.StoreName = nameInput.text;
            SceneManager.LoadScene("Game");
        }
    }

    public void InvisibleText(bool isSelected)
    {
        if (isSelected)
            placeHolder.text = "";
        else
            placeHolder.text = placeHolderText;
    }
}
