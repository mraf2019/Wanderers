using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class OnlinePlayer : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject playerCamera;
    public TMPro.TMP_Text PlayerNameText;

    public int maxHealth = 100;
    public float speed = 4;

    public List<CardInfo> cards = new List<CardInfo>();
    public SkillInfo skill;

    private Vector2 lookDirection = new Vector2(1, 0);
    private int currentHealth;

    public bool isInvincible = false;
    private float invincibleTimer;
    private float timeInvincible = 3.0f;

    private void Awake()
    {
        if (photonView.isMine)
        {
            PlayerNameText.text = PhotonNetwork.player.NickName;
        }
        else
        {
            PlayerNameText.text = photonView.owner.NickName;
            PlayerNameText.color = Color.cyan;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (photonView.isMine)
        {
            Move();
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    private void Move()
    {
        var joysticks = GameObject.FindGameObjectsWithTag("Joystick");
        if (joysticks.Length <= 0)
        {
            return;
        }
        Vector2 joystickVec = joysticks[0].GetComponent<Joystick>().joystickVec;
        if (joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystickVec.x * speed, joystickVec.y * speed);
            lookDirection.Set(rb.velocity.x, rb.velocity.y);
            lookDirection.Normalize();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);

        animator.SetFloat("Move X", rb.velocity.x);
        animator.SetFloat("Move Y", rb.velocity.y);
    }

    public void ChangeHealth(int amount, bool isRegion)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            Debug.Log(amount);
            animator.SetTrigger("Hit");
            if (isRegion)
            {
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        UIHealthBar.instance.Setvalue(currentHealth / (float)maxHealth);
    }

    public void CollectCards(CardInfo card)
    {
        cards.Add(card);
    }

//    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//    {
//        if (stream.isWriting)
//        {
//            stream.SendNext(rb.velocity.x);
//            stream.SendNext(rb.velocity.y);
//        }
//        else
//        {
//            rb.velocity.x = stream.ReceiveNext();

//        }
//    }
}
