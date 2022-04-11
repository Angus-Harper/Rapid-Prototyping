using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firingPoint;

    public float projectileSpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.right * projectileSpeed);
            Destroy(projectileInstance, 3f);
        }
    }
}
