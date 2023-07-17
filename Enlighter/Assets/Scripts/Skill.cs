using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public struct SkillInfo
{
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public bool attack;
    [SerializeField] public int healthChange;
}

public class Skill : MonoBehaviour
{
    public int idx;
    public Player player;
    public bool isSelected = false;
    public float initialX;
    public float initialY;
    public SkillInfo skill;
    private bool active = false;
    private Image img;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        tf = GetComponent<Transform>();
        skill = player.skill;
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
            SkillManager.Instance.OnSkillSelected(this);
        }
    }
}
