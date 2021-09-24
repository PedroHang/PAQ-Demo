using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    

    public TextMeshProUGUI text;
    public static int score; 

     void Awake()
    {
    }
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "x"+score.ToString();
    }

}
