using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_Text rank;
    public TMPro.TMP_Text total;

    private Image img;
    void Start()
    {
        rank.text = PlayerPrefs.GetInt("rank").ToString();
        total.text = PlayerPrefs.GetInt("totalNum").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
