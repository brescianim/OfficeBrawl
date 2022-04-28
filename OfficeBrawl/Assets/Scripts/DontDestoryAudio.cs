using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryAudio : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}

