using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnlineSkillManager : MonoBehaviour
{
    public static OnlineSkillManager Instance; // Singleton instance

    private OnlineSkill selectedSkill;
    private OnlinePlayer selectedPlayer;
    private EnemyController selectedEnemy;
    private List<GameObject> skillObjects = new List<GameObject>();

    void Start()
    {
        GameObject skillObject = GameObject.Find("Canvas/CharacterSkill");
        skillObjects.Add(skillObject);
    }

    private void Awake()
    {
        // Ensure only one instance of the skillManager exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void OnSkillSelected(OnlineSkill skill)
    {
        // Set the new selected skill
        selectedSkill = skill;
    }

    public void OnTargetPlayerSelected(OnlinePlayer player)
    {
        // If a card is selected and a target is clicked, use the skill's effect on the target
        if (selectedSkill != null)
        {
            if (!selectedSkill.skill.attack)
            {
                // Implement your skill's effect logic here
                // For example: selectedSkill.UseEffect(target);
                selectedPlayer = player;
                selectedPlayer.ChangeHealth(selectedSkill.skill.healthChange);

                // Reset the card's selection state after using the skill
                selectedSkill.isSelected = false;
            }

            // Clear the selected card and target references
            selectedSkill.ResetSkill();
            selectedSkill = null;
            selectedPlayer = null;
        }
    }

    public void OnTargetEnemySelected(EnemyController enemy)
    {
        // If a skill is selected and a target is clicked, use the skill's effect on the target
        if (selectedSkill != null)
        {
            if (selectedSkill.skill.attack)
            {
                // Implement your skill's effect logic here
                // For example: selectedSkill.UseEffect(target);
                selectedEnemy = enemy;
                selectedEnemy.ChangeHealth(selectedSkill.skill.healthChange);
                Debug.Log("health changed");
            }

            // Clear the selected skill and target references
            selectedSkill.ResetSkill();
            selectedSkill = null;
            selectedEnemy = null;
        }
    }
}
