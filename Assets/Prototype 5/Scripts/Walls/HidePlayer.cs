using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    public bool hidden = false;
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hidden = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hidden = false;
        }
    }
}
