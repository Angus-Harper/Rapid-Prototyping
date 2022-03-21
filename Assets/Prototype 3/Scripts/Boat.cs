using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float speed = 0.2f;
    public int rot;
    float x = 5;
    // Start is called before the first frame update
    void Start()
    {
        randomRotate();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * x * speed);

        if (rot == 0)
        {
            StartCoroutine(Wait());
        }
        else if (rot == 1)
        {
            transform.Rotate(Vector3.forward * speed);
            StartCoroutine(Wait());
        }
        else if (rot == 2)
        {
            transform.Rotate(Vector3.forward * -speed);
            StartCoroutine(Wait());
        }
    }

    private void randomRotate()
    {
        rot = Random.Range(0, 3);
    }

    IEnumerator Wait()
    {
        Debug.Log("Hello");
        yield return new WaitForSeconds(x);
        randomRotate();
    }
}
