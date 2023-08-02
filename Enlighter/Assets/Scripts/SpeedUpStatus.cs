using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpStatus : MonoBehaviour
{
    public static SpeedUpStatus instance { get; private set; }
    public Image speedUpIcon;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        speedUpIcon = GetComponent<Image>();
        speedUpIcon.enabled = true;
    }

    // Update is called once per frame
    public void SetSpeedUp(bool show)
    {
        speedUpIcon = GetComponent<Image>();
        speedUpIcon.enabled = show;
    }
}
