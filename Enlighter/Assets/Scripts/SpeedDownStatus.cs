using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDownStatus : MonoBehaviour
{
    public static SpeedDownStatus instance { get; private set; }
    public Image speedDownIcon;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        speedDownIcon = GetComponent<Image>();
        speedDownIcon.enabled = true;
    }

    // Update is called once per frame
    public void SetSpeedDown(bool show)
    {
        speedDownIcon = GetComponent<Image>();
        speedDownIcon.enabled = show;
    }
}
