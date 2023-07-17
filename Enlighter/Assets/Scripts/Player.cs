using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rb;
    public int maxHealth = 100;
    public List<CardInfo> cards = new List<CardInfo>();
    public SkillInfo skill;
    int currentHealth;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (!Mathf.Approximately(rb.velocity.x, 0.0f) || !Mathf.Approximately(rb.velocity.y, 0.0f))
        {
            lookDirection.Set(rb.velocity.x, rb.velocity.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);

        animator.SetFloat("Move X", rb.velocity.x);
        animator.SetFloat("Move Y", rb.velocity.y);
    }


    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth);
        UIHealthBar.instance.Setvalue(currentHealth / (float)maxHealth);
    }

    public void CollectCards(CardInfo card)
    {
        cards.Add(card);
    }

    public void OnPointerClick()
    {
        // Notify the card manager (or other script) about the target selection
        CardManager.Instance.OnTargetPlayerSelected(this);
    }
}
