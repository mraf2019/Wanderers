using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onlinePlayer : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject playerCamera;

    public int maxHealth = 100;
    public Joystick joystick;
    public float speed = 4;
    private Vector2 lookDirection = new Vector2(1, 0);

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (photonView.isMine)
        {
            Move();
        }
    }

    private void Move()
    {
        if (joystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
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
}
