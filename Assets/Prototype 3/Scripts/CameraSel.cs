using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSel : MonoBehaviour
{
    public GameObject[] cameraCon;

    public int cameraNum;
    // Start is called before the first frame update
    void Start()
    {
        CameraFalse();
        cameraCon[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraFalse();
            cameraNum++;
            if (cameraNum > 4)
            {
                cameraNum = 0;
            }
            cameraCon[cameraNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CameraFalse();
            cameraNum--;
            if (cameraNum < 0)
            {
                cameraNum = 4;
            }
            cameraCon[cameraNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraFalse();
            cameraNum = 0;
            cameraCon[cameraNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CameraFalse();
            cameraNum = 1;
            cameraCon[cameraNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CameraFalse();
            cameraNum = 2;
            cameraCon[cameraNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CameraFalse();
            cameraNum = 3;
            cameraCon[cameraNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CameraFalse();
            cameraNum = 4;
            cameraCon[cameraNum].SetActive(true);
        }
    }

    void CameraFalse()
    {
        for (int i = 0; i < cameraCon.Length; i++)
        {
            cameraCon[i].SetActive(false);
        }
    }
}
