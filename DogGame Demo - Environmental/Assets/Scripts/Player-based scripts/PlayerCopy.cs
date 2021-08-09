using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;
using TMPro;

public class PlayerCopy : Player
{
    private Rigidbody rb;
    float randomic;
    private GameObject RealPlayer;

    Vector3 SavedPosition;
    
    Animator animator;

    void Awake(){
        Time.timeScale = 1;       // OVERRIDE REAL PLAYER'S PAUSE ON AWAKE
    }
    void Start()
    {
        randomic = Random.Range(-1.2f, 1.2f);


        SavedPosition =  GameObject.FindGameObjectWithTag("Player").transform.position;   // SPAWN POSITION
        transform.position = SavedPosition + (Vector3.right * randomic);
        onGround = true;
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        RealPlayer = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        //

        
        if(Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.E)){
            displayMenu();
        }


        if(onGround || MAX_JUMP > currentJump){

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.position.y > Screen.height / 3)
                {
                    rb.velocity = new Vector3(0f, 7f, 0f);
                    animator.SetBool("isJumping", true);
                    currentJump++;
                    onGround = false;
                }
            }
        }

        if(onGround || MAX_JUMP > currentJump){

                if (Input.GetKeyDown("space"))
                {
                    rb.velocity = new Vector3(0f, 7f, 0f);
                    animator.SetBool("isJumping", true);
                    currentJump++;
                    onGround = false;
                }
        }

        if(onGround){
            GetComponent<Rigidbody>().drag = 0f;
        }

        GetComponent<Rigidbody>().drag = RealPlayer.GetComponent<Rigidbody>().drag;
    }

    void OnCollisionEnter(Collision other) {

        // SETTING REPULSION ORB = TRUE

        if(other.gameObject.CompareTag("DJOrb")){
            repulsionOrb = true;
            Destroy(other.gameObject);
            Debug.Log("FOI");
            textPowerUp.gameObject.SetActive(true);
            MAX_JUMP = 2;
        }

        // ---------------------------


        // SETTING GROUND

        if(other.gameObject.CompareTag("Ground")){
            speed = 6f;
            onGround = true;
            currentJump = 0;
            animator.SetBool("isJumping", false);
        }

        // ----------------------------


        // SETTING MUD

        if(other.gameObject.CompareTag("Mud")){
            speed = 3f;
            onGround = true;
            animator.SetBool("isJumping", false);
            animator.speed = 0.8f;
        }

        // ----------------------------



        if(other.collider.tag == "Enemy"){
            Destroy(this.gameObject);
        }

        if(other.collider.tag == "Wall"){
            Destroy(this.gameObject);
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

        if(other.gameObject.CompareTag("StartFlying")){     //GLIDE EFFECT
            GetComponent<Rigidbody>().drag = 5.0f;
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("BoostCoin");
        }
    }
    
}
