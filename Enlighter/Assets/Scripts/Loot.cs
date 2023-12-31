using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    public List<CardInfo> cards = new List<CardInfo>();
    private List<GameObject> cardObjects = new List<GameObject>();
    public GameObject targetF;
    public GameObject targetT;

    void Start()
    {
        for (int i = 1; i <= 5; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/Cards/Card" + i.ToString());
            cardObjects.Add(cardObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        targetF.SetActive(false);
        targetT.SetActive(true);
        if (player != null){
            foreach (var card in cards)
            {
                player.CollectCards(card);
            }
            foreach (var cardObject in cardObjects)
            {
                Card card = cardObject.GetComponent<Card>();
                card.UpdateCard();
            }
            Destroy(gameObject);
        }
        
        
    }
}
