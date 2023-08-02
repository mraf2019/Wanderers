using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public OnlinePlayer currentPlayer;
    public ShopCard shopcard;

    public void OnPointerClick()
    {
        if (currentPlayer.currency < shopcard.card.price)
        {
            return;
        }
        Debug.Log(-1 * shopcard.card.price);
        currentPlayer.ChangeCurrency(-1 * shopcard.card.price);
        currentPlayer.CollectCards(shopcard.card);
        shopcard.UpdatePlayerCards();
        shopcard.ClearCard();
    }
}
