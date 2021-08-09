using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPush : MonoBehaviour
{

    private GameObject Player;

    public float speed;

    bool isInArea = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    void Push()
    {
        if (isInArea == true)
        {
            Player.transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInArea = true;
        }

    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isInArea = false;
        }
    }
}
