using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;

    public Transform[] pos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Spawn();
        }
    }
    
    void Spawn()
    {
        float enemyPos = Random.Range(0, pos.Length + 1);

        for (int i = 0; i < enemyPos; i++)
        {
            Instantiate(enemy, pos[i].position, pos[i].rotation);
        }
    }
}
