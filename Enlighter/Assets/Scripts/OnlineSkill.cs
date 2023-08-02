using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnlineSkill : MonoBehaviour
{
    public int idx;
    public GameObject playerPrefab;
    public bool isSelected = false;
    public float initialX;
    public float initialY;
    public SkillInfo skill;

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
        skill = player.mySkill;
        Sprite skillImg = Resources.Load<Sprite>("Skills/"+skill.name);
        img.sprite = skillImg;
        active = true;
        initialX = tf.localScale.x;
        initialY = tf.localScale.y;
    }


    public void ResetSkill()
    {
        tf.localScale = new Vector2(initialX, initialY);
        isSelected = false;
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
                Debug.Log("skill selected");
            }
            else
            {
                ResetSkill();
            }

            // Notify the card manager (or other script) about the card selection
            //OnlineSkillManager.Instance.OnSkillSelected(this);
        }
    }
}
