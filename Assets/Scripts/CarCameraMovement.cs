using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraMovement : MonoBehaviour
{
    public float SpeedV = 0.2f;
    public float SpeedH = 0.2f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Update is called once per frame
    void Update()
    {
        rotationY += SpeedV * Input.GetAxis("Mouse X");
        rotationX -= SpeedH * Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, -30f, 30f);
        rotationY = Mathf.Clamp(rotationY, 160f, 200f);


        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
