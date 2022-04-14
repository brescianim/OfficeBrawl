using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public MenuController menuController;

    private int count = 100;

    //private Rigidbody rb;
    //private float movementX;
    //private float movementY;
    //private int rock;

    // Start is called before the first frame update

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    count = 0;

    //    SetCountText();

    //}

    //private void Update()
    //{

    //}

    //void OnMove(InputValue movementValue)
    //{
    //    Vector2 movementVector = movementValue.Get<Vector2>();

    //    movementX = movementVector.x;
    //    movementY = movementVector.y;
    //}

    void SetCountText()
    {
        countText.text = "Boss HP: " + count.ToString();
    }

    void OnMouseDown()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Respawn();

        }
        if (collision.gameObject.CompareTag("WinRock") && rock == 1)
        {
            //winTextObject.SetActive(true);
            menuController.WinGame();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

}