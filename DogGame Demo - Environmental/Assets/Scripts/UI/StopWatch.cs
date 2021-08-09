using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    float timer;
    float seconds;
    float minutes;

    [SerializeField] Text stopWatchText;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        StopWatchCalcul();
    }

    void StopWatchCalcul(){
        timer += Time.deltaTime;
        seconds = (int) (timer % 60);
        minutes = (int) (timer / 60);

        stopWatchText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
