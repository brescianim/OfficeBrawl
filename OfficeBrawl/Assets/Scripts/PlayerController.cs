using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public MenuController menuController;
    public Text HP; //The UIText_Level Text

    public int count = 100;

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

    void UpdateGUI()
    {
        HP.text = "Boss HP: " + count;
    }


    private void Update()
    {
        UpdateGUI();

        if (Input.GetMouseButtonUp(0))
        {
            count = count - 10;
        }
    }

    void OnMouseDown()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("PickUp"))
    //    {
    //        other.gameObject.SetActive(false);
    //        count = count + 1;

    //        SetCountText();
    //    }
    //}



    //void Respawn()
    //{
    //    rb.velocity = Vector3.zero;
    //    rb.angularVelocity = Vector3.zero;
    //    rb.Sleep();
    //    transform.position = respawnPoint.position;
    //}

}