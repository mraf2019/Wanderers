using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    public int idx;
    public CardInfo card;
    public Image img;

    private List<GameObject> cardObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        for (int i = 1; i <= 5; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/Cards/Card" + i.ToString());
            cardObjects.Add(cardObject);
        }
    }

    public void UpdateCard()
    {
        if (idx < ShopController.Instance.count)
        {
            Sprite cardImg = Resources.Load<Sprite>("Cards/" + card.name);
            img.sprite = cardImg;
        }
        else
        {
            ClearCard();
        }
    }

    public void UpdatePlayerCards()
    {
        foreach (var cardObject in cardObjects)
        {
            OnlineCard card = cardObject.GetComponent<OnlineCard>();
            card.UpdateCard();
        }
    }

    public void ClearCard()
    {
        Sprite cardImg = Resources.Load<Sprite>("Cards/BlankCard");
        img.sprite = cardImg;
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
