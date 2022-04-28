using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhillipController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public float moveSpeed = 5f;
    public DummySettings dummy;
    public Animator p_animator;
    public Animator w_animator;
    public MenuController menuController;

    public GameObject pencilLocation;
    public BoxCollider2D pencilCollider;
    public GameObject dummyObject;
    public BoxCollider2D dummyCollider;

    private bool hasHorizontalInput;
    private bool isWalking;

    private bool hasAttackInput;
    private bool isAttacking;

    public AudioClip stab;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p_animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void meleeAttack(bool isAttacking, BoxCollider2D pencil, BoxCollider2D dummyCollider)
    {
        if (isAttacking)
        {
            if (pencil.IsTouching(dummyCollider))
            {
                dummy.count -= 10;
            }
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        hasHorizontalInput = !Mathf.Approximately(movement.x, 0f);
        isWalking = hasHorizontalInput;
        p_animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                p_animator.Play("phillip_walk_left");
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                p_animator.Play("phillip_walk_right");
            }
        }

        AttackInput();
        End();
    }

    void WyattJudgement()
    {
        if (dummy.count <= 200 && dummy.count > 140)
        {
            w_animator.Play("wyatt_bg_200");
        } else if (dummy.count <= 140 && dummy.count > 80)
        {
            w_animator.Play("wyatt_bg_140");
        } else if (dummy.count <= 80 && dummy.count > 40)
        {
            w_animator.Play("wyatt_bg_80");
        } else if (dummy.count <= 40)
        {
            w_animator.Play("wyatt_bg_40");
        }
    }

    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            hasAttackInput = true;
            isAttacking = hasAttackInput;
            p_animator.SetBool("isAttacking", isAttacking);
            source.PlayOneShot(stab);

            if (isAttacking)
            {
                if (p_animator.GetCurrentAnimatorStateInfo(0).IsName("phillip_idle_left"))
                {
                    p_animator.Play("phillip_melee_left");
                    meleeAttack(isAttacking, pencilCollider, dummyCollider);
                }
                else if (p_animator.GetCurrentAnimatorStateInfo(0).IsName("phillip_idle_right"))
                {
                    p_animator.Play("phillip_melee_right");
                    meleeAttack(isAttacking, pencilCollider, dummyCollider);
                }
            }

            hasAttackInput = false;
            isAttacking = hasAttackInput;
            p_animator.SetBool("isAttacking", isAttacking);

            if (!isAttacking)
            {
                if (p_animator.GetCurrentAnimatorStateInfo(0).IsName("phillip_melee_left"))
                {
                    p_animator.Play("phillip_idle_left");
                }
                else if (p_animator.GetCurrentAnimatorStateInfo(0).IsName("phillip_melee_right"))
                {
                    p_animator.Play("phillip_idle_right");
                }
            }
        }
    }

    void End()
    {
        if (dummy.count == 0)
        {
            menuController.WinGame();
            AudioSource win = GetComponent<AudioSource>();
            win.Play();

        }
    }

    // Update is called once per frame
    void Update()
    {
        WyattJudgement();
    }
}
