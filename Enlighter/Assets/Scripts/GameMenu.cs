using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void ExitGame()
    {
        PhotonNetwork.Disconnect();
        Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
        SceneManager.LoadScene("Start Menu");
    }
    public void EnterCharacter()
    {
        SceneManager.LoadScene("Character MVP");
    }
}
