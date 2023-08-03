using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    public int count = 3;
    public OnlinePlayer cuurentPlayer;

    private List<GameObject> cardObjects = new List<GameObject>();

    private void Awake()
    {
        // Ensure only one instance of the CardManager exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/ShopUI/Cards/Card" + i.ToString());
            ShopCard card = cardObject.GetComponent<ShopCard>();
            card.card = Constanat.cardList[Random.Range(0, 11)];
            card.UpdateCard();
            ShopButton shopButton = card.transform.GetChild(0).gameObject.GetComponent<ShopButton>();
            shopButton.currentPlayer = cuurentPlayer;
            shopButton.shopcard = card;
            shopButton.transform.GetChild(1).gameObject.GetComponent<TMPro.TMP_Text>().text = card.card.price.ToString();
            cardObjects.Add(cardObject);
        }
    }


}
