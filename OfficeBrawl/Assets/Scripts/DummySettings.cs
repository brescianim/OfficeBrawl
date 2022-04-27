using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummySettings : MonoBehaviour
{
    public Text HP;
    public int count = 200;

    void UpdateGUI()
    {
        HP.text = "Boss HP: " + count;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
    }
}
