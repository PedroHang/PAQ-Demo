using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCount : MonoBehaviour
{
    public int dogValue;
    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider Player) {
        if(Player){
            DogManager.instance.ChangeScoreDog(dogValue);
            FindObjectOfType<AudioManager>().Play("BoostCoin");
        }
    }
}
