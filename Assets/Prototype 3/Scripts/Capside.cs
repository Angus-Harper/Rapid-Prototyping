using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z > 100 && transform.localEulerAngles.z < 180 || transform.localEulerAngles.z > 180 && transform.localEulerAngles.z < 260)
        {
            SceneManager.LoadScene("Title");
        }
        else
        {

        }  
    }
}
