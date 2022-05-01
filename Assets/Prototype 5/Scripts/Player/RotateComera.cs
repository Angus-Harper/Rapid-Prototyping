using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComera : MonoBehaviour
{
    public float rotateSpeed;
    float e = 0;
    float q = 0;

    public Transform focusPoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            e = 1;
        }
        else
        {
            e = 0;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            q = 1;
        }
        else
        {
            q = 0;
        }
        float horizontalInput = q - e;
        focusPoint.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotateSpeed);
    }
}
