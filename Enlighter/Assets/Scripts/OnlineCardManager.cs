using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnlineCardManager : MonoBehaviour
{
    public static OnlineCardManager Instance; // Singleton instance
    public OnlinePlayer cuurentPlayer;

    private OnlineCard selectedCard;
    private OnlinePlayer selectedPlayer;
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

    public void OnCardSelected(OnlineCard card)
    {
        // If another card is already selected, deselect it first
        if (selectedCard != null && selectedCard != card)
        {
            if (selectedCard.isSelected)
            {
                selectedCard.ResetCard();
                selectedCard.isSelected = false;
            }
        }

        // Set the new selected card
        selectedCard = card;
    }

    public void OnTargetPlayerSelected(OnlinePlayer player, bool isSelf)
    {
        // If a card is selected and a target is clicked, use the card's effect on the target
        if (selectedCard != null)
        {
            Debug.Log(isSelf);
            Debug.Log(selectedCard.card.healthChange);
            if ((isSelf && !selectedCard.card.attack) || (!isSelf && selectedCard.card.attack))
            {
                // Implement your card's effect logic here
                // For example: selectedCard.UseEffect(target);
                selectedPlayer = player;
                PhotonView photonView = PhotonView.Get(selectedPlayer);
                photonView.RPC("ChangeHealth", PhotonTargets.Others, selectedCard.card.healthChange, false);

                // Reset the card's selection state after using the card
                selectedCard.isSelected = false;
                selectedCard.ClearCard();
                cuurentPlayer.cards.RemoveAt(selectedCard.idx);
                foreach (var cardObject in cardObjects)
                {
                    OnlineCard card = cardObject.GetComponent<OnlineCard>();
                    card.UpdateCard();
                }
            }

            // Clear the selected card and target references
            selectedCard.ResetCard();
            selectedCard = null;
            selectedPlayer = null;
        }
    }
}
