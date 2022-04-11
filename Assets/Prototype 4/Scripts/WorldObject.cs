using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public GameObject balloon;
    public int balloonCount = 5;
    private float spawnRangex = 8;
    private float spawnRangey = 4;
    public float time = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time - 1 * Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(balloon, GenerateSpawnPosition(), balloon.transform.rotation);
            time = 10;
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
