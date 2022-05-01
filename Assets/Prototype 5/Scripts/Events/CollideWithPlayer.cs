using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    public ControlPanel panel;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panel.True();
            other.transform.position = new Vector3(-72.8f, -75.2f, -29);
        }
    }
}
