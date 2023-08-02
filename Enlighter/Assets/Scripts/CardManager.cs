using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance; // Singleton instance
    public Player cuurentPlayer;

    private Card selectedCard;
    private Player selectedPlayer;
    private EnemyController selectedEnemy;
    private List<GameObject> cardObjects = new List<GameObject>();

    void Start()
    {
        for (int i = 1; i <= 5; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/Cards/Card" + i.ToString());
            cardObjects.Add(cardObject);
        }
    }

    private void Awake()
    {
        // Ensure only one instance of the CardManager exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void OnCardSelected(Card card)
    {
        // If another card is already selected, deselect it first
        if (selectedCard != null && selectedCard != card)
        {
            selectedCard.ResetCard();
            selectedCard.isSelected = false;
        }

        // Set the new selected card
        selectedCard = card;
    }

    public void OnTargetPlayerSelected(Player player)
    {
        // If a card is selected and a target is clicked, use the card's effect on the target
        if (selectedCard != null)
        {
            if (!selectedCard.card.attack)
            {
                // Implement your card's effect logic here
                // For example: selectedCard.UseEffect(target);
                selectedPlayer = player;
                selectedPlayer.ChangeHealth(selectedCard.card.healthChange);

                // Reset the card's selection state after using the card
                selectedCard.isSelected = false;
                selectedCard.ClearCard();
                cuurentPlayer.cards.RemoveAt(selectedCard.idx);
                foreach (var cardObject in cardObjects)
                {
                    Card card = cardObject.GetComponent<Card>();
                    card.UpdateCard();
                }
            }

            // Clear the selected card and target references
            selectedCard.ResetCard();
            selectedCard = null;
            selectedPlayer = null;
        }
    }

    public void OnTargetEnemySelected(EnemyController enemy)
    {
        // If a card is selected and a target is clicked, use the card's effect on the target
        if (selectedCard != null)
        {
            if (selectedCard.card.attack)
            {
                // Implement your card's effect logic here
                // For example: selectedCard.UseEffect(target);
                selectedEnemy = enemy;
                selectedEnemy.ChangeHealth(selectedCard.card.healthChange);

                // Reset the card's selection state after using the card
                selectedCard.isSelected = false;
                selectedCard.ClearCard();
                cuurentPlayer.cards.RemoveAt(selectedCard.idx);
                foreach (var cardObject in cardObjects)
                {
                    Card card = cardObject.GetComponent<Card>();
                    card.UpdateCard();
                }
            }

            // Clear the selected card and target references
            selectedCard.ResetCard();
            selectedCard = null;
            selectedEnemy = null;
        }
    }
}
