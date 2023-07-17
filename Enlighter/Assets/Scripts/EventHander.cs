using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class EventHander : MonoBehaviour
{
    public static event Action GetGameOverEvent;
    public static void CallGetGameOverEvent()
    {
        Debug.Log("End the game.");
        SceneManager.LoadScene("Result");
    }
}


