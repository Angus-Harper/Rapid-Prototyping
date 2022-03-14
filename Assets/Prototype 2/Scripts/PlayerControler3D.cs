using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler3D : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float pspeed = x + z;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (pspeed != 0 && (transform.rotation.y != cam.rotation.y))
        {
            transform.rotation = cam.rotation;
        }
    }
}
