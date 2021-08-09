using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public bool onGround;
    public float speed = 6f;
    private Rigidbody rb;
    public int MAX_JUMP = 1;
    public int currentJump = 0;

    public bool isInArea = false;
    public bool repulsionOrb = false;
    public bool doubleJump = false;
    public bool boosted = false;
    public TextMeshProUGUI textPowerUp;
    public GameObject gameMenu;

    public GameObject powerUpButton;
    public GameObject BarkProjectile;
    public GameObject SuperpositionDog;
    public float JumpHeight;
 
    Animator animator;


    void Awake(){
        Time.timeScale = 0;      // INTERACTION WITH MAIN MENU, INITIAL PAUSE
    }

    void Start()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        DogManager.dogScore = 0; 
        
    }

    void Update()
    {     // Simplified Update Method
        KeyboardControl();

        if(onGround){
            GetComponent<Rigidbody>().drag = 0f;
        }
        JumpingKeyboard();
    }

    public void FixedUpdate()    
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;  // MOVING

        JumpingTouch();
    }

    void JumpingTouch(){        // Jump using mobile touch
        if(onGround || MAX_JUMP > currentJump){
                Touch touch = Input.GetTouch(0);

                if (touch.position.y > Screen.height / 3)
                {
                    rb.velocity = new Vector3(0f, JumpHeight, 0f);
                    animator.SetBool("isJumping", true);
                    FindObjectOfType<AudioManager>().Play("Jump");
                    currentJump++;
                    onGround = false;
                    
                }

        }
    }

    void JumpingKeyboard(){        //JUMP USING KEYBOARD
        if(onGround || MAX_JUMP > currentJump){

            
                
                if (Input.GetKeyDown("space"))
                {
                    rb.velocity = new Vector3(0f, JumpHeight, 0f);
                    animator.SetBool("isJumping", true);
                    FindObjectOfType<AudioManager>().Play("Jump");
                    currentJump++;
                    onGround = false;


                }
        }
    }

    void KeyboardControl(){
        if(Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.E)){
            displayMenu();
        }
    }

    

    public void Replay()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(0);              // PLAYER DEFEAT OR RESTART BTN
    }

    public void displayMenu()
    {
        SceneManager.LoadScene(1);
    }

    void OnCollisionEnter(Collision other) {

        // Double-Jump

        if(other.gameObject.CompareTag("DJorb")){
            repulsionOrb = true;
            Destroy(other.gameObject);
            textPowerUp.gameObject.SetActive(true);
            MAX_JUMP = 2;
        }

        // ---------------------------


        // Ground

        if(other.gameObject.CompareTag("Ground")){
            speed = 6f;
            onGround = true;
            currentJump = 0;
            animator.SetBool("isJumping", false);
        }

        // ----------------------------


        // Mud

        if(other.gameObject.CompareTag("Mud")){
            speed = 3f;
            onGround = true;
            animator.SetBool("isJumping", false);
            animator.speed = 0.8f;
        }

        // ----------------------------



        if(other.collider.tag == "Enemy"){
            Replay();
        }

        if(other.collider.tag == "End"){
            gameMenu.gameObject.SetActive(true);
            this.gameObject.GetComponent<TouchMove>().disableMoving();
            Time.timeScale = 0;
        }
    }

    IEnumerator waitSeconds2(){
        yield return new WaitForSeconds(2);          // BOOST FOR 2 SECONDS
        speed = 7f;
    }

    IEnumerator waitSeconds3(){
        yield return new WaitForSeconds(3);          // BOOST FOR 3 SECONDS
        speed = 7f;
    }


    private void OnTriggerEnter(Collider other) {
        isInArea = true;
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }

        if(other.gameObject.CompareTag("BoostCoin")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("BoostCoin");
            speed = 10f;
            StartCoroutine(waitSeconds2());

        }

        if(other.gameObject.CompareTag("StartFlying")){     // Glide effect
            GetComponent<Rigidbody>().drag = 3.0f;
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("BoostCoin");
        }
    }

    // Power-ups --------------------------------------
    public void SpeedPowerUpButton(){
        speed = 15f;
        StartCoroutine(waitSeconds3());
        ScoreManager.score = 0;
        powerUpButton.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Power");
    }

    public void BarkPowerUpButton(){
        GameObject Bark = Instantiate(BarkProjectile);
        ScoreManager.score = 0;
        powerUpButton.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Power");
    }

    public void SuperpositionPowerUpButton(){
        GameObject Superposition = Instantiate(SuperpositionDog);
        ScoreManager.score = 0;
        powerUpButton.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Power");
    }

    // ------------------------------------------------------
    
}
