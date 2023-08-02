using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    public int count = 3;
    private List<GameObject> cardObjects = new List<GameObject>();
    public OnlinePlayer currentPlayer;

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
            cardObject.GetComponent<ShopCard>().card = Constanat.cardList[Random.Range(0, 10)];
            cardObject.GetComponent<ShopCard>().UpdateCard();
            cardObjects.Add(cardObject);
        }
    }


}
