using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public TextMeshPro nameText;

    private void Start()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
