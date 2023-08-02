using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Portraits : MonoBehaviour
{
    public int playerindex;

    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        playerindex = PlayerPrefs.GetInt("SelectedCharacterIndex");
        if(playerindex == 0)
        {
            Sprite portraitImg = Resources.Load<Sprite>("Portraits/Ivy");
            img.sprite = portraitImg;
        }
        else if(playerindex == 1)
        {
            Sprite portraitImg = Resources.Load<Sprite>("Portraits/Raine");
            img.sprite = portraitImg;
        }
        else
        {
            Sprite portraitImg = Resources.Load<Sprite>("Portraits/Raelia");
            img.sprite = portraitImg;
        }
    }
}
