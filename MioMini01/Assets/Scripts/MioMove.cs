using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MioMove : MonoBehaviour
{
    float rotationTime = 5f;
    
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        NormalMove();
    }

    public void NormalMove()
    {
        Quaternion minRot = Quaternion.Euler(new Vector3(0,0, 9));
        Quaternion maxRot = Quaternion.Euler(new Vector3(0,0, -5));
        float rotationDelta = Mathf.PingPong(Time.time / rotationTime, 1);

        Quaternion targetRotation = Quaternion.Slerp(minRot, maxRot, rotationDelta);

        this.transform.GetComponent<Rigidbody2D>().MoveRotation(targetRotation);
        
    }

}
