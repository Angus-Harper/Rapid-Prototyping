using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    //public GameObject rock;
    float z = -1;
    public float speed = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, z);


        gameObject.transform.Translate(movement * speed * Time.deltaTime);

        if (gameObject.transform.position.z <= -20)
        {
            Destroy(gameObject);
        }
    }
}
