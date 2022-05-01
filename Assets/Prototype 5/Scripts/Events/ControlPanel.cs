using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    bool pressed = false;
    bool playerIsIn = false;
    public bool lockMouse = false;
    public Turret turret;
    public GameObject game1;
    public PlayerControllerP5 player;
    public PauseControler pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && pressed == false && playerIsIn == true)
        {
            pause.doNoHideMouse = true;
            if (lockMouse == false)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {

            }
            game1.SetActive(true);
            player.hasControl = false;
        }
    }
    void OnTriggerEnter()
    {
        playerIsIn = true;
    }
    void OnTriggerExit()
    {
        playerIsIn = false;
    }

    public void True()
    {
        turret.health -= 1;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        pressed = true;
        pause.doNoHideMouse = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.hasControl = true;
        game1.SetActive(false);
    }

    public void False()
    {
        pause.doNoHideMouse = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.hasControl = true;
        game1.SetActive(false);
    }
}
