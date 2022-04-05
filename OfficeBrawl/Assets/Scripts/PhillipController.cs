using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhillipController : MonoBehaviour
{
    public RigidBody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigidBody2D>();
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
