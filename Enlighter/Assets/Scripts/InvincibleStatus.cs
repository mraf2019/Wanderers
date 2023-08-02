using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvincibleStatus : MonoBehaviour
{
    public static InvincibleStatus instance { get; private set; }
    public Image invincibleIcon;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        invincibleIcon = GetComponent<Image>();
        invincibleIcon.enabled = true;
    }

    // Update is called once per frame
    public void SetInvincible(bool show)
    {
        invincibleIcon = GetComponent<Image>();
        invincibleIcon.enabled = show;
    }
}
