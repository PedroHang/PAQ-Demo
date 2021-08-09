using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed = 6f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
