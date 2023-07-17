using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Characters : MonoBehaviour
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
