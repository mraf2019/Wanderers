using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx;
    public Player player;
    string name = "";
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int l = player.cards.Count;
        if (idx < l)
        {
            name = player.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/"+name);
            img.sprite = cardImg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int l = player.cards.Count;
        if (idx < l)
        {
            name = player.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/" + name);
            img.sprite = cardImg;
        }
    }
}
