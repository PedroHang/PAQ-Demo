using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
