using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;




public class PauseManager : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public TextMeshProUGUI Text;
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public void menuPlay(){
        Time.timeScale = 1;
        Text.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
    }

    public void gamePause(){ // WHEN PAUSE BUTTON IS PRESSED
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }

     public void gameResume(){
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void restartLevel(){
        ScoreManager.score = 0;
        DogManager.dogScore = 0;
        SceneManager.LoadScene(0);
    }

    public void disableButon(){
        pauseButton.gameObject.SetActive(false);
    }
}
