using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image Bar;
    private static int thisscore;

    public GameObject powerUpButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        thisscore = ScoreManager.score;
        current = thisscore;
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        Bar.fillAmount = fillAmount;
        if(current >= maximum/2){
            Bar.color = new Color32(255,255,0,200);
        }

        if(current >= maximum){
            powerUpButton.gameObject.SetActive(true);
            Bar.color = new Color32(102,255,51,200);
        }
    }
}
