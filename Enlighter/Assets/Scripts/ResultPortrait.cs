using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPortrait : MonoBehaviour
{
    public int playerindex;

    private Image img;
    void Start()
    {
        img = GetComponent<Image>();
        playerindex = PlayerPrefs.GetInt("SelectedCharacterIndex");
        if(playerindex == 0)
        {
            Sprite portraitImg = Resources.Load<Sprite>("Portraits/IvyPortrait");
            img.sprite = portraitImg;
        }
        else if(playerindex == 1)
        {
            Sprite portraitImg = Resources.Load<Sprite>("Portraits/RainePortrait");
            img.sprite = portraitImg;
        }
        else
        {
            Sprite portraitImg = Resources.Load<Sprite>("Portraits/RaeliaPortrait");
            img.sprite = portraitImg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
