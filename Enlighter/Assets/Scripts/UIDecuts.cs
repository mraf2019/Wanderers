using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDecuts : MonoBehaviour
{
    public static UIDecuts instance;
    private TMPro.TMP_Text num;

    private void Start()
    {
        num = GetComponent<TMPro.TMP_Text>();
    }

    void Awake()
    {
        instance = this;
    }

    public void Setvalue(int n)
    {
        num.text = n.ToString();
    }
}
