using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLimits : MonoBehaviour
{
    public static float leftSide = 89.15f;
    public static float rightSide = 96.35f;
    public float internalLeft;
    public float internalRight;
    

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
