using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanes : MonoBehaviour
{
   public float Lane1Pos = 0;
   public float Lane2Pos = 5;
   public float Lane3Pos = 10;

   public float CurrentPos = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(CurrentPos == 0)
            {
                transform.localPosition = new Vector3(Lane2Pos, 0, 0);
                CurrentPos = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            if(CurrentPos == 1)
            {
                transform.localPosition = new Vector3(Lane3Pos, 0, 0);
                CurrentPos = 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            if(CurrentPos == 2)
            {
                CurrentPos = 0;
                transform.localPosition = new Vector3(Lane1Pos, 0, 0);
            }
        }
    }
}
