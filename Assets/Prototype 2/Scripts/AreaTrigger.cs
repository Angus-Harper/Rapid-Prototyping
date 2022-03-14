using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public GameObject sign;

    public List<GameObject> enemies;

    public void AddEnemeies(GameObject enemy)
    {
        enemies.Add(enemy);
        sign.GetComponent<Renderer>().material.color = Color.red;
    }

    public void RemoveEnemies(GameObject enemy)
    {
        Debug.Log(enemy.name);
        enemies.Remove(enemy);
        Destroy(enemy, .5f);
        if (enemies.Count == 0)
        {
            sign.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
