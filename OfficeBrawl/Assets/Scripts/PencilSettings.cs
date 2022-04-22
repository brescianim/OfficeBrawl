using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSettings : MonoBehaviour
{
    public DummySettings dummy;

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("TestDummy") && dummy.count > 0)
        {
            dummy.count -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
