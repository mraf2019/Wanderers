using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text roomNameText;
    [SerializeField] private Transform playerListContent;
    [SerializeField] private GameObject PlayerListItemPrefab;
    [SerializeField] private GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.SetActive(false);
        roomNameText.text = PhotonNetwork.room.Name;
        StartCoroutine("updatePlayerlist");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator updatePlayerlist()
    {
        while (true)
        {
            PhotonPlayer[] players = PhotonNetwork.playerList;
            if (players.Length >= 1 && PhotonNetwork.isMasterClient) // if there are other players and this is the host
            {
                startButton.SetActive(true);
            }
            foreach (Transform child in playerListContent)
            {
                Destroy(child.gameObject);
            }
            for (int i = 0; i < players.Length; i++)
            {
                Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void ExitRoom()
    {
        PhotonNetwork.LeaveRoom();
        //SceneManager.LoadScene("Start Menu");
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
