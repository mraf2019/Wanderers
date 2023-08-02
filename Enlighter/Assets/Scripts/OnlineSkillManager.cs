using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


//[System.Serializable]
//public struct SkillInfo
//{
//    [SerializeField] public string name;
//    [SerializeField] public string description;
//    [SerializeField] public bool attack;
//    [SerializeField] public int healthChange;
//}

public class OnlineSkillManager : MonoBehaviour
{
    public static OnlineSkillManager Instance; // Singleton instance
    //public Player cuurentPlayer;
    public float coldTime = 5.0f;

    //private SkillInfo selectedSkill;
    private OnlinePlayer selectedPlayer;
    private EnemyController selectedEnemy;
    private List<GameObject> skillObjects = new List<GameObject>();
    private float timer = 0;
    public Image filledImage;
    private bool ifStartTimer = false;

    public OnlinePlayer player;
    public bool isSelected = false;
    public float initialX;
    public float initialY;
    public SkillInfo skill;
    public Image img;
    private Transform tf;
    public PhotonView photonView;
    private bool ifLoaded = false;

    void Start()
    {
        //GameObject skillObject = GameObject.Find("Canvas/CharacterSkill");
        //skillObjects.Add(skillObject);
        if (photonView.isMine)
        {

            //for skill image
            isSelected = false;
            img = transform.Find("CharacterSkill").GetComponent<Image>();
            tf = transform.Find("CharacterSkill").GetComponent<Transform>();
            //skill = player.skill;
            img.sprite = Resources.Load<Sprite>("Skills/" + skill.name);
            Debug.Log(skill.name + "loaded");
            ifStartTimer = false;
            initialX = tf.localScale.x;
            initialY = tf.localScale.y;
            //for filled image
            filledImage = transform.Find("CharacterSkillCold").GetComponent<Image>();
            filledImage.sprite = Resources.Load<Sprite>("Skills/fillBackground");

        }
    }

    private void Awake()
    {
        // Ensure only one instance of the skillManager exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    //public void OnSkillSelected(SkillInfo skill)
    //{
    //    // Set the new selected skill
    //    selectedSkill = skill;
    //}

    public void OnTargetPlayerSelected(OnlinePlayer player)
    {
        // If a card is selected and a target is clicked, use the skill's effect on the target
        if (isSelected)
        {
            if (!skill.attack)
            {
                // Implement your skill's effect logic here
                // For example: selectedSkill.UseEffect(target);
                selectedPlayer = player;
                selectedPlayer.ChangeHealth(skill.healthChange, false);

                // Reset the card's selection state after using the skill
                isSelected = false;
            }

            // Clear the selected card and target references
            ResetSkill();
            selectedPlayer = null;
        }
    }

    public void OnTargetEnemySelected(EnemyController enemy)
    {
        // If a skill is selected and a target is clicked, use the skill's effect on the target
        if (isSelected)
        {
            if (skill.attack)
            {
                // Implement your skill's effect logic here
                // For example: selectedSkill.UseEffect(target);
                selectedEnemy = enemy;
                selectedEnemy.ChangeHealth(skill.healthChange);
                Debug.Log("health changed");
            }

            // Clear the selected skill and target references
            ResetSkill();
            //selectedSkill.name = null;
            selectedEnemy = null;

            ifStartTimer = true;
        }
    }

    //for skill
    public void ResetSkill()
    {
        tf.localScale = new Vector2(initialX, initialY);
        isSelected = false;
    }

    public void OnPointerClick()
    {
        Debug.Log("skill clicked");
        if (!ifStartTimer && photonView.isMine)
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

            //// Notify the card manager (or other script) about the card selection
            //Instance.OnSkillSelected(skill);
        }
    }

    private void Update()
    {
        if (skill.name != "" && !ifLoaded)
        {
            img.sprite = Resources.Load<Sprite>("Skills/" + skill.name);
            ifLoaded = true;
        }
        if (ifStartTimer)
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = (coldTime - timer) / coldTime;
            if (timer >= coldTime)
            {
                filledImage.fillAmount = 0;
                timer = 0;
                ifStartTimer = false;
            }
        }
    }
}




//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class OnlineSkillManager : MonoBehaviour
//{
//    public static OnlineSkillManager Instance; // Singleton instance

//    private OnlineSkill selectedSkill;
//    private OnlinePlayer selectedPlayer;
//    private EnemyController selectedEnemy;
//    private List<GameObject> skillObjects = new List<GameObject>();

//    void Start()
//    {
//        GameObject skillObject = GameObject.Find("Canvas/CharacterSkill");
//        skillObjects.Add(skillObject);
//    }

//    private void Awake()
//    {
//        // Ensure only one instance of the skillManager exists
//        if (Instance == null)
//            Instance = this;
//        else if (Instance != this)
//            Destroy(gameObject);
//    }

//    public void OnSkillSelected(OnlineSkill skill)
//    {
//        // Set the new selected skill
//        selectedSkill = skill;
//    }

//    public void OnTargetPlayerSelected(OnlinePlayer player)
//    {
//        // If a card is selected and a target is clicked, use the skill's effect on the target
//        if (selectedSkill != null)
//        {
//            if (!selectedSkill.skill.attack)
//            {
//                // Implement your skill's effect logic here
//                // For example: selectedSkill.UseEffect(target);
//                selectedPlayer = player;
//                selectedPlayer.ChangeHealth(selectedSkill.skill.healthChange);

//                // Reset the card's selection state after using the skill
//                selectedSkill.isSelected = false;
//            }

//            // Clear the selected card and target references
//            selectedSkill.ResetSkill();
//            selectedSkill = null;
//            selectedPlayer = null;
//        }
//    }

//    public void OnTargetEnemySelected(EnemyController enemy)
//    {
//        // If a skill is selected and a target is clicked, use the skill's effect on the target
//        if (selectedSkill != null)
//        {
//            if (selectedSkill.skill.attack)
//            {
//                // Implement your skill's effect logic here
//                // For example: selectedSkill.UseEffect(target);
//                selectedEnemy = enemy;
//                selectedEnemy.ChangeHealth(selectedSkill.skill.healthChange);
//                Debug.Log("health changed");
//            }

//            // Clear the selected skill and target references
//            selectedSkill.ResetSkill();
//            selectedSkill = null;
//            selectedEnemy = null;
//        }
//    }
//}
