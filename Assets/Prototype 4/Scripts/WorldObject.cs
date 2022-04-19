using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldObject : MonoBehaviour
{
    public TMP_Text ammo;
    public TMP_Text target;
    public GameObject balloon;
    public Door door;
    private float spawnRangex = 8;
    private float spawnRangey = 4;
    public float time = 5;
    public int ammoType = 1;
    public bool won;
    public bool chall;
    public static int normal;
    // Start is called before the first frame update
    void Start()
    {
        if (normal == 0)
        {
            door.doorTarget = 0;
            chall = false;
        }
        else if (normal == 1)
        {
            door.doorTarget = Random.Range(-100, 100);
            chall = true;
        }

        won = false;
        normal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        target.text = "Get the door to " + door.doorTarget;
        time = time - 1 * Time.deltaTime;
        if (time <= 0 && won == false)
        {
            Instantiate(balloon, GenerateSpawnPosition(), balloon.transform.rotation);
            time = 3;
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
        if (Input.GetKeyDown(KeyCode.Alpha3) && chall == true)
        {
            ammoType = 3;
            ammo.text = "*";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && chall == true)
        {
            ammoType = 4;
            ammo.text = "/";
        }
    }

    private Vector3 GenerateSpawnPosition()  // Vector3 can replace Voids only if we "return" a value
    {
        float spawnPosX = Random.Range(-spawnRangex, spawnRangex);
        float spawnPosY = Random.Range(0, spawnRangey);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }

    public void ButtonClickedNorm()
    {
        Debug.Log("norm = 0");
        normal = 0;
    }

    public void ButtonClickedChall()
    {
        Debug.Log("norm = 1");
        normal = 1;
    }
}
