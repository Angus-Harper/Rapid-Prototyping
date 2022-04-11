using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2d : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x;

        controller.Move(move * speed * Time.deltaTime);
    }
}
