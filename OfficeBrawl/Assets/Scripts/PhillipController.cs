using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhillipController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            print("Phillip's main attack!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        AttackInput();
    }
}
