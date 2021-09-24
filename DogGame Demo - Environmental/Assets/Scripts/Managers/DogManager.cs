using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DogManager : MonoBehaviour
{
    public static DogManager instance;   
    public TextMeshProUGUI DogCount;
    public static int dogScore; 

    void Awake()
    {
    }
    
    void Start()
    {
        dogScore = 0;

        if(instance == null){
            instance = this;
        }
    }

    public void ChangeScoreDog(int dogValue)
    {
        dogScore += dogValue;
        DogCount.text = "x"+dogScore.ToString();
    }
}
