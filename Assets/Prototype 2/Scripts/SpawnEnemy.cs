using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;

    public Transform[] pos;
    public List<AreaTrigger> areaTrigger;

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
            GameObject go = Instantiate(enemy, pos[i].position, pos[i].rotation);
            areaTrigger[i].AddEnemeies(go);
        }
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
