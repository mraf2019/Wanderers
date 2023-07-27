using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float roundTime;
    public float stopTime;
    public int maxHealth = 100;
    public EnemyHealthBar healthBar;

    int currentHealth;
    Rigidbody2D rigidbody2d;
    float timer;
    float stopTimer;
    int direction = 1; // 1 means y+delta_y
    bool move = true;
    bool trigger = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        timer = roundTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (timer < 0){
        //     if (stopTimer < 0){
        //         direction = -direction;
        //         timer = roundTime;
        //         stopTimer = stopTime;
        //         move = true;
        //         animator.SetTrigger("Move");
        //         trigger = false;
        //     }
        //     else{
        //         move = false;
        //         if (!trigger){
        //             animator.SetTrigger("Stop");
        //             trigger = true;
        //         }
        //         stopTimer -= Time.fixedDeltaTime;
        //     }
        // }
        // else{
        //     timer -= Time.fixedDeltaTime;
        // }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        // if (move){
        //     Vector2 position = rigidbody2d.position;
        //     position.y = position.y + Time.fixedDeltaTime * speed * direction;
        //     animator.SetFloat("MoveX", 0);
        //     animator.SetFloat("MoveY", direction);

        //     rigidbody2d.MovePosition(position);
        // }
        // else{
        //     animator.SetFloat("FaceX", 0);
        //     animator.SetFloat("FaceY", direction);
        // }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
        }
        Debug.Log(currentHealth);
        healthBar.Setvalue(currentHealth / (float)maxHealth);
        if (currentHealth == 0)
        {
            GameManagerTutorial.Instance.PlayerDestroyed();
        }
    }

    public Vector2 GetPos()
    {
        return rigidbody2d.position;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void OnPointerClick()
    {
        CardManager.Instance.OnTargetEnemySelected(this);
        SkillManager.Instance.OnTargetEnemySelected(this);
    }
}
