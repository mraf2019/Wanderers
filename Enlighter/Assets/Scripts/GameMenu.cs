using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void EnterCharacter()
    {
        SceneManager.LoadScene("Character MVP");
    }
}
