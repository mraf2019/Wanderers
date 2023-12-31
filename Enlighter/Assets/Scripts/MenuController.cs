using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string version = "0.0.1";

    [SerializeField] private TMPro.TMP_InputField usernameInput;
    [SerializeField] private TMPro.TMP_InputField createGameInput;
    [SerializeField] private TMPro.TMP_InputField joinGameInput;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject createGameButton;
    [SerializeField] private GameObject joinGameButton;

    private string msg;

    private void Update()
    {
        if (msg!= PhotonNetwork.connectionStateDetailed.ToString())
        {
            msg = PhotonNetwork.connectionStateDetailed.ToString();
            Debug.Log(msg);
        }
    }

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(version);
        PhotonNetwork.automaticallySyncScene = true;
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("connected");
    }

    public void ChangeUsernameInput()
    {
        if (usernameInput.text.Length > 3)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void CreateGameRoomNumberInput()
    {
        if (usernameInput.text.Length >= 4)
        {
            createGameButton.SetActive(true);
        }
        else
        {
            createGameButton.SetActive(false);
        }
    }

    public void JoinGameRoomNumberInput()
    {
        if (usernameInput.text.Length >= 4)
        {
            joinGameButton.SetActive(true);
        }
        else
        {
            joinGameButton.SetActive(false);
        }
    }

    public void setUsername()
    {
        PhotonNetwork.playerName = usernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createGameInput.text, new RoomOptions() { maxPlayers = 5 }, null);
        
    }

    public void JoinGame()
    {
        PhotonNetwork.JoinOrCreateRoom(joinGameInput.text, new RoomOptions() { maxPlayers = 5 }, null);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Room");
    }
}
