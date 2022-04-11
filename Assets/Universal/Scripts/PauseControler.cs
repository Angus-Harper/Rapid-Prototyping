using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControler : GameBehaviour
{

    public GameObject pausePanel;
    bool pause = false;
    public bool doNoHideMouse;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (doNoHideMouse == false)
        {
            if (pause == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {

        }
    }

    public void Pause()
    {
        Debug.Log("fdesge");
        pause = !pause;
        pausePanel.SetActive(pause);
        Time.timeScale = pause ? 0 : 1; // changes game speed 0 = stop, 0.5 = half, 1 = full speed, 2 = double speed
        if (pause == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
