using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerP5 : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public float jumpHieght = 3f;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float turnTime = 0.1f;
    public float turn;
    public float rotateSpeed;
    public int health = 20;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    public bool hidden = true;
    public bool hasControl = true;
    [Header("will disable the third person control")]
    public bool firstPerson;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("DeadEndingP5");
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 18f;
        }
        else
        {
            speed = 6f;
        }
        if (hasControl)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            float pspeed = x + z;

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            //if first person disable this, if third person enable
            if (firstPerson == false)
            {
                transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotateSpeed);
                /*
                if (pspeed != 0 && (transform.rotation.y != cam.rotation.y))
                {
                    transform.rotation = cam.rotation;
                }
                */
            }
            else
            {

            }
        }
        else
        {

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
