using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public Navigation navigation;

    public TMP_Text nameText;

    private void Start()
    {
        nameText.text = GameManager.Instance.StoreName;
    }
}
