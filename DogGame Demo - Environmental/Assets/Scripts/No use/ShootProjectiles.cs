using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject fireslot;
    [SerializeField] private Transform pfBullet;

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
        nextActionTime += period;
         GameObject.Instantiate(pfBullet, fireslot.transform.position, fireslot.transform.rotation);
        }
    }
}
