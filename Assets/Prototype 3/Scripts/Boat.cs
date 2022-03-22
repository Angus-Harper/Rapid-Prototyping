using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float speed = 0.2f;
    public float force = 0.05f;
    float rotate;
    public int rot;
    public float timer;
    float maxTime = 500f / 60;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        randomRotate();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - 1f * Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * x * speed);

        if (timer <= 0)
        {
            randomRotate();
        }
        if (rot == 0)
        {
        }
        else if (rot == 1)
        {
            transform.Rotate(Vector3.forward * force);
        }
        else if (rot == 2)
        {
            transform.Rotate(Vector3.forward * -force);
        }
    }

    private void randomRotate()
    {
        rot = Random.Range(0, 3);
        timer = maxTime;
    }
}
