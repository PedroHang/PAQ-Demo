using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            FindObjectOfType<AudioManager>().Play("Tp");
            other.gameObject.transform.position = new Vector3(220, -2, 466);
        }
    }
}
