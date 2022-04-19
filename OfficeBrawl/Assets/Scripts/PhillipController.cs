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
    public Animator m_animator;
    public MenuController menuController;

    private bool hasHorizontalInput;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        hasHorizontalInput = !Mathf.Approximately(movement.x, 0f);
        isWalking = hasHorizontalInput;
        m_animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                m_animator.Play("phillip_walk_left");
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                m_animator.Play("phillip_walk_right");
            }
        }

        End();
    }

    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            print("Phillip's main attack!");
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("TestDummy") && dummy.count >0)
        {
            dummy.count -= 10;
        }
    }

    void End()
    {
        if (dummy.count == 0)
        {
            menuController.WinGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        AttackInput();
    }
}
