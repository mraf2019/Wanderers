using System.Collections.Generic;
using UnityEngine;

public class OnlineLoot : MonoBehaviour
{
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    public List<CardInfo> cards = new List<CardInfo>();
    private List<GameObject> cardObjects = new List<GameObject>();

    void Start()
    {
        for (int i = 1; i <= 5; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/Cards/Card" + i.ToString());
            cardObjects.Add(cardObject);
        }
        int idx1 = Random.Range(0, 11);
        int idx2 = Random.Range(0, 11);
        CardInfo card1 = Constanat.cardList[idx1];
        cards.Add(card1);
        CardInfo card2 = Constanat.cardList[idx2];
        cards.Add(card2);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnlinePlayer player = other.GetComponent<OnlinePlayer>();

        Debug.Log("loot collided");

        if (player != null)
        {
            foreach (var card in cards)
            {
                player.CollectCards(card);
            }
            foreach (var cardObject in cardObjects)
            {
                OnlineCard card = cardObject.GetComponent<OnlineCard>();
                card.UpdateCard();
            }
            Destroy(gameObject);
        }


    }

}
