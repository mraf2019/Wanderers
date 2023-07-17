using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float roundTime;
    public float stopTime;
    public int maxHealth = 100;

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
        Debug.Log(currentHealth);
    }

    private void OnMouseDown()
    {
        // Notify the card manager (or other script) about the target selection
        CardManager.Instance.OnTargetEnemySelected(this);
    }
}
