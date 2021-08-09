using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        TouchMover();
    }

    void TouchMover(){
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if ((touch.position.x < Screen.width/2) || (touch.position.y > Screen.height/3))
            {
                //MOVE LEFT
                transform.Translate(-moveSpeed, 0, 0);
            }

            if ((touch.position.x > Screen.width/2) || (touch.position.y > Screen.height/3))
            {
                //MOVE RIGHT
                transform.Translate(moveSpeed, 0, 0);
            }

        }
    }

    public void disableMoving(){
        moveSpeed = 0f;
    }
// INTERACTION WITH PAUSE BUTTON
    public void enableMoving(){
        moveSpeed = 0.1f;
    }
}
