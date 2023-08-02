using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CardInfoRaw
{
    [SerializeField] public string name;
    [SerializeField] public int id;
    [SerializeField] public string is_attack;
    [SerializeField] public int health_change;
    [SerializeField] public float speed_change;
    [SerializeField] public int money;
    [SerializeField] public bool invincible;
    [SerializeField] public int price;
}

public class ShopCard : MonoBehaviour
{
    public int idx;
    public CardInfo card;

    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        
    }

    void UpdateCard()
    {
        if(idx < ShopController.Instance.count)
        {
            card = ShopController.Instance.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/" + card.name);
            img.sprite = cardImg;
        }
        else
        {
            ClearCard();
        }
    }

    public void ClearCard()
    {
        Sprite cardImg = Resources.Load<Sprite>("Cards/BlankCard");
        img.sprite = cardImg;
    }
}
