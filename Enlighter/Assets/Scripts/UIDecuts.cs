using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDecuts : MonoBehaviour
{
    public static UIDecuts instance;
    private TMPro.TMP_Text num;
    void Awake()
    {
        instance = this;
    }

    public void Setvalue(int n)
    {
        num.text = n.ToString();
    }
}
