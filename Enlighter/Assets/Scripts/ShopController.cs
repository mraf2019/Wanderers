using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    public int count = 3;
    public List<CardInfo> cards = new List<CardInfo>();
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
        int randomInt1 = Random.Range(0, 11);
        int randomInt2 = Random.Range(0, 11);
        int randomInt3 = Random.Range(0, 11);
        for (int i = 1; i <= 5; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/ShopUI/Cards/Card" + i.ToString());
            cardObjects.Add(cardObject);
        }
    }


}
