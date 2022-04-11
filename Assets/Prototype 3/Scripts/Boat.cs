using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour
{
    public float speed = 0.8f;
    public float force = 0.05f;
    float rotate;
    public int rot;
    public int rotRead;
    public float timer;
    float postTimer;
    float maxTime = 500f / 60;

    public GameObject image;
    public Texture[] windSock;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - 1f * Time.deltaTime;
        postTimer = postTimer - 1f * Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * x * speed);
        image.GetComponent<RawImage>().texture = windSock[rot];
        if (timer <= 0)
        {
            randomRotate();
        }
        if (rot == 0)
        {
            rotRead = 0;
        }
        else if (rot == 1)
        {
            if (postTimer <= 0)
            {
                transform.Rotate(Vector3.forward * force);
            }
            rotRead = 1;
        }
        else if (rot == 2)
        {
            if (postTimer <= 0)
            {
                transform.Rotate(Vector3.forward * -force);
            }
            rotRead = 2;
        }
    }

    private void randomRotate()
    {
        rot = Random.Range(0, 3);
        timer = maxTime;
        if (rot == rotRead)
        {

        }
        else
        {
            postTimer = maxTime / 2;
        }
    }
}
