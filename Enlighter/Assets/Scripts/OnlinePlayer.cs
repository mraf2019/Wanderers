using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnlinePlayer : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject playerCamera;
    public TMPro.TMP_Text PlayerNameText;
    public string userName;

    public int maxHealth = 100;
    public float initialSpeed = 4;
    public float speed = 4;
    public int currency;

    public List<CardInfo> cards = new List<CardInfo>();
    public SkillInfo mySkill;

    public bool isInvincible = false;

    private Vector2 lookDirection = new Vector2(1, 0);
    private int currentHealth;
    private bool isSelf = false;

    private float invincibleTimer;
    private float timeInvincible = 3.0f;

    //speed related
    public bool isSpeedUp = false;
    private float speedupTimer;
    private float speedupTimes = 0;
    private float timeSpeedUp = 10.0f;

    public bool isSpeedDown = false;
    private float speeddownTimer;
    private float speeddownTimes = 0;
    private float timeSpeedDown = 10.0f;

    float speedTimes;

    private OnlineCardManager Cards;

    private void Awake()
    {
        if (photonView.isMine)
        {
            PlayerNameText.text = PhotonNetwork.player.NickName;
            PlayerNameText.color = Color.cyan;
        }
        else
        {
            PlayerNameText.text = photonView.owner.NickName;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        Cards = OnlineCardManager.Instance;
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
            isSelf = true;
            OnlineSkillManager skill = GameObject.Find("Canvas/GameUI/Skill").GetComponent<OnlineSkillManager>();
            skill.skill = mySkill;
            Debug.Log("skillinfo loaded");
        }
        currentHealth = maxHealth;
        userName = photonView.photonView.owner.NickName;
        currency = 1000;
    }

    // Update is called once per frame
    private void Update()
    {
        if (photonView.isMine)
        {
            Move();
            UIHealthBar.instance.Setvalue(currentHealth / (float)maxHealth);
            Cards.cuurentPlayer = this;
            if(ShopController.Instance)
                ShopController.Instance.cuurentPlayer = this;
            for (int i = 0; i < 5; i++)
            {
                Cards.transform.GetChild(i).gameObject.GetComponent<OnlineCard>().player = this;
            }
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (isSpeedUp)
        {
            speedupTimer -= Time.deltaTime;
            if (speedupTimer < 0)
            {
                isSpeedUp = false;
                speed = initialSpeed;
                speedupTimes = 0;
                speedupTimer = 0;
            }
        }
        if (isSpeedDown)
        {
            speeddownTimer -= Time.deltaTime;
            if (speeddownTimer < 0)
            {
                isSpeedDown = false;
                speed = initialSpeed;
                speeddownTimes = 0;
                speedupTimer = 0;
            }
        }

        // determine status
        if (speed > initialSpeed) SpeedUpStatus.instance.SetSpeedUp(true);
        else if (speed <= initialSpeed) SpeedUpStatus.instance.SetSpeedUp(false);

        if (speed < initialSpeed) SpeedDownStatus.instance.SetSpeedDown(true);
        else if (speed >= initialSpeed) SpeedDownStatus.instance.SetSpeedDown(false);

        if (isInvincible) InvincibleStatus.instance.SetInvincible(true);
        else InvincibleStatus.instance.SetInvincible(false);
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

    public void ChangeCurrency(int amount)
    {
        if(currency + amount < 0)
            return;
        Debug.Log(currency + amount);
        UIDecuts.instance.Setvalue(currency + amount);
        currency += amount;
    }

    public void ChangeHealth(int amount, bool isRegion)
    {

        if (amount < 0)
        {
            if (isInvincible)
                return;
            animator.SetTrigger("Hit");
            if (isRegion)
            {
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        if (currentHealth <= 0)
        {
            PhotonNetwork.Instantiate("loot", transform.position, Quaternion.identity, 0);
            gameObject.SetActive(false);
            GameManager.Instance.EndGame();
        }
    }

    public void ChangeSpeed(float times, bool increase)
    {
        if (times > 0)
        {
            if (isInvincible)
                return;
            Debug.Log(times);
            if(increase)
                isSpeedUp = true;
            else
                isSpeedDown = true;
            animator.SetTrigger("Hit");
            if (increase)
            {
                speedupTimer = 10f;
                speedupTimes += times;
            }
            else
            {
                speeddownTimer = 10f;
                speeddownTimes += times;
            }
        }

        // calculate speed
        if (speedupTimes != 0 || speeddownTimes != 0)
        {
            speedTimes = speedupTimes - speeddownTimes;
            speed = initialSpeed * (1 + speedTimes);
        }
    }

    public void CollectCards(CardInfo card)
    {
        cards.Add(card);
    }

    public void OnPointerClick()
    {
        // Notify the card manager (or other script) about the target selection
        OnlineCardManager.Instance.OnTargetPlayerSelected(this, isSelf);
        OnlineSkillManager.Instance.OnTargetPlayerSelected(this, isSelf);
    }

    [PunRPC]
    public void Hurt(int amount, string target)
    {
        Debug.Log(target);
        if (target != userName)
        {
            return;
        }
        ChangeHealth(amount, false);
    }

    [PunRPC]
    public void ChangeSpeed(float amount, string target)
    {
        bool negative = amount < 0;
        Debug.Log(target);
        Debug.Log(negative);
        if(target != userName)
            return;
        if(negative)
            ChangeSpeed(amount,!negative);
        else
            ChangeSpeed(amount,!negative);
    }
}
