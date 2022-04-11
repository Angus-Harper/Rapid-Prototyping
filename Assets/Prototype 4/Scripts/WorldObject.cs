using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldObject : MonoBehaviour
{
    public TMP_Text ammo;
    public GameObject balloon;
    private float spawnRangex = 8;
    private float spawnRangey = 4;
    public float time = 5;
    public int ammoType;
    public bool won; 
    // Start is called before the first frame update
    void Start()
    {
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - 1 * Time.deltaTime;
        if (time <= 0 && won == false)
        {
            Instantiate(balloon, GenerateSpawnPosition(), balloon.transform.rotation);
            time = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ammoType = 1;
            ammo.text = "+";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ammoType = 2;
            ammo.text = "-";
        }
    }

    private Vector3 GenerateSpawnPosition()  // Vector3 can replace Voids only if we "return" a value
    {
        float spawnPosX = Random.Range(-spawnRangex, spawnRangex);
        float spawnPosY = Random.Range(0, spawnRangey);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }
}
