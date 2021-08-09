using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCoin : MonoBehaviour
{
    
    public int coinValue = 1;

    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider Player) {
        if(Player){
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
