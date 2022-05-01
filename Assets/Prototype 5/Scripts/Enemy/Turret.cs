using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject player;
    public GameObject chaingun;
    public GameObject projectilePrefab;
    public GameObject door;
    public Transform firingPoint;
    public float speed = 5;
    public float maxDistance = 100f;
    public float projectileSpeed = 500f;
    public float time;
    public int health = 4;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            transform.LookAt(player.transform);
            chaingun.transform.Rotate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward); // start at player and end where the players is looking
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    if (speed < 500)
                    {
                        speed = speed + 5;
                    }
                }
                if (hitInfo.collider.CompareTag("Wall"))
                {
                    if (speed > 0)
                    {
                        speed = speed - 5;
                    }
                }
            }
        }
        else 
        {
            Destroy(door);
        }

        if (speed >= 500)
        {
            time = time - 1;
            if (time <= 0)
            {
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
                projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.right * projectileSpeed);
                Destroy(projectileInstance, 3f);
                time = 20;
            }
        }
    }
}
