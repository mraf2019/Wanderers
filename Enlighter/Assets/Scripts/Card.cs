using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx;
    public Player player;
    private string name = "";
    private bool active = false;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int l = player.cards.Count;
        if (idx < l)
        {
            name = player.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/"+name);
            img.sprite = cardImg;
            active = true;
        }
    }

    // Update is called once per frame
    public void UpdateCard()
    {
        int l = player.cards.Count;
        if (idx < l)
        {
            name = player.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/" + name);
            img.sprite = cardImg;
            active = true;
        }
    }
}
