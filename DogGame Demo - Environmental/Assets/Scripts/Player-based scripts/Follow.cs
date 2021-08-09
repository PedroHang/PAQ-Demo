using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
 public GameObject wayPoint;
 private Vector3 wayPointPos;
 private float speed = 0.0f;
 private float speedUp = 0.0f;

 IEnumerator waitSeconds3(){
        yield return new WaitForSeconds(3);          // Wait for 3 seconds
        Destroy(this.gameObject);
    }

 private void OnTriggerEnter(Collider other) {
     if(other.gameObject.CompareTag("Player")){
         speed = 5.0f;
         speedUp = 5.0f;
         StartCoroutine(waitSeconds3());
     }
 }
 
 void Update ()
 {

      wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
      // The follower will follow the waypoint
      transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
      transform.Translate(Vector3.up * speedUp * Time.deltaTime);
 }
}
