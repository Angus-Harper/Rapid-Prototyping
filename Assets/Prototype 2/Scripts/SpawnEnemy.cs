using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;

    public Transform[] pos;
    public List<AreaTrigger> areaTrigger;

    public int enemyCount;

    int enemyPos;

    int enemyNumber;
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
            enemyNumber = Random.Range(0, 8);
           // StarSpawn();

            for (int i = 0; i < enemyNumber; i++)
            {
                enemyPos = Random.Range(0, pos.Length + 1);
                Spawn();
            }
        }
    }
    
    void StarSpawn()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            enemyPos = Random.Range(0, pos.Length + 1);
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject go = Instantiate(enemy, pos[enemyPos].position, pos[enemyPos].rotation);
        areaTrigger[enemyPos].AddEnemeies(go);
    }

    public void Kill(GameObject enemy)
    {
        for(int i = 0; i < areaTrigger.Count; i++)
        { 
            if (areaTrigger[i].enemies.Contains(enemy))
            {
                areaTrigger[i].RemoveEnemies(enemy);
            }
        }
    }
}
