using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScene : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Start Menu");
    }
}


