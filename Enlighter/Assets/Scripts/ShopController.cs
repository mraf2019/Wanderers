using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfoRaws
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public CardInfoRaw[] cardsRawInfos;
}

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    public int count = 3;
    public List<CardInfo> cards = new List<CardInfo>();
    private List<GameObject> cardObjects = new List<GameObject>();
    public OnlinePlayer currentPlayer;

    private int randomInt1;
    private int randomInt2;
    private int randomInt3;

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
        randomInt1 = Random.Range(0, 11);
        randomInt2 = Random.Range(0, 11);
        randomInt3 = Random.Range(0, 11);
        CardInfoRaws cardsRaw = JsonUtility.FromJson<CardInfoRaws>("./cards.json");
        foreach (var cardsRawInfo in cardsRaw.cardsRawInfos)
        {
            Debug.Log(cardsRawInfo.id);
        }
        for (int i = 1; i <= 3; i++)
        {
            GameObject cardObject = GameObject.Find("Canvas/GameUI/ShopUI/Cards/Card" + i.ToString());
            cardObjects.Add(cardObject);
        }
    }


}
