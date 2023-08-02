using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public int price;
    public OnlinePlayer currentPlayer;
    public ShopCard card;

    public void OnPointerClick()
    {
        if (currentPlayer.currency < price)
        {
            return;
        }
        Debug.Log(-1 * price);
        currentPlayer.ChangeCurrency(-1 * price);
        currentPlayer.CollectCards(card.card);
        card.UpdateCard();
        card.ClearCard();
    }
}
