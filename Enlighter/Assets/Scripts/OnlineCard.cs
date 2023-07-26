using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnlineCard : MonoBehaviour
{
    public int idx;
    public bool isSelected = false;
    public float initialX;
    public float initialY;
    public CardInfo card;
    public GameObject playerPrefab;

    private bool active = false;
    private Image img;
    private Transform tf;
    private OnlinePlayer player;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        tf = GetComponent<Transform>();
        player = playerPrefab.GetComponent<OnlinePlayer>();
        int l = player.cards.Count;
        if (idx < l)
        {
            card = player.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/"+card.name);
            img.sprite = cardImg;
            active = true;
        }
        initialX = tf.localScale.x;
        initialY = tf.localScale.y;
    }

    public void UpdateCard()
    {
        int l = player.cards.Count;
        if (idx < l)
        {
            card = player.cards[idx];
            Sprite cardImg = Resources.Load<Sprite>("Cards/" + card.name);
            img.sprite = cardImg;
            active = true;
        } else
        {
            ClearCard();
        }
    }

    public void ResetCard()
    {
        tf.localScale = new Vector2(initialX, initialY);
        Vector2 tmp = tf.position;
        tf.position = tmp + new Vector2(0, -75);
        isSelected = false;
    }

    public void ClearCard()
    {
        active = false;
        Sprite cardImg = Resources.Load<Sprite>("Cards/BlankCard");
        img.sprite = cardImg;
    }

    public void OnPointerClick()
    {
        if (active)
        {
            // When the card is clicked, toggle its selection state
            isSelected = !isSelected;

            // Show visual feedback to indicate the selection
            if (isSelected)
            {
                Vector2 scaleUp = new Vector2(initialX + 0.5f, initialY + 0.5f);
                tf.localScale = scaleUp;
                Vector2 tmp = tf.position;
                tf.position = tmp + new Vector2(0, 75);
                Debug.Log("selected");
            }
            else
            {
                ResetCard();
            }

            // Notify the card manager (or other script) about the card selection
            OnlineCardManager.Instance.OnCardSelected(this);
        }
    }
}
