using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class OnlineManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputName;
    public TMP_InputField inputRoomName;
    public Button submitButton;
    bool isConnected = false;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        submitButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to Lobby");
        isConnected = true;
    }

    public void JoinRoom()
    {
        PhotonNetwork.NickName = inputName.text;

        RoomOptions roomOptions = new RoomOptions { IsVisible = true, MaxPlayers = 5 };

        PhotonNetwork.JoinOrCreateRoom(inputRoomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    private void Update()
    {
        if (isConnected)
        {
            submitButton.interactable = true;
            submitButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Katıl";
        }
        else
        {
            submitButton.interactable = false;
            submitButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Bağlanılıyor..";
        }
    }
}
