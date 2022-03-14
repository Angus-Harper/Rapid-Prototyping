using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [Header("Raycast Stuff")]
    public float maxDistance = 100f;
    public LayerMask layerMask;

    public SpawnEnemy spawnEnemy;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward); // start at player and end where the players is looking
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
            {
                hitInfo.collider.GetComponent<Renderer>().material.color = Color.red;
                spawnEnemy.Kill(hitInfo.collider.gameObject);
            }
        }
    }
}
