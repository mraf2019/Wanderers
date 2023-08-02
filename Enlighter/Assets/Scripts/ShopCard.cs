using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShopCard : MonoBehaviour
{
    public int idx;
    public CardInfo card;
    public List<CardInfo> cards = new List<CardInfo>();

    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    void UpdateCard()
    {
        if(idx < ShopController.Instance.count)
        {
            card = ShopController.Instance.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/" + card.name);
            img.sprite = cardImg;
        }
        else
        {
            ClearCard();
        }
    }

    public void ClearCard()
    {
        Sprite cardImg = Resources.Load<Sprite>("Cards/BlankCard");
        img.sprite = cardImg;
    }
}
