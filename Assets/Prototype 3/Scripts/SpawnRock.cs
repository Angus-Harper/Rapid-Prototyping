using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    public GameObject[] rock;
    public GameObject[] spawn;
    public float time;
    public float minTime = 12;
    public float maxTime = 508;
    // Start is called before the first frame update
    void Start()
    {

        time = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        time = time -1 * Time.deltaTime;
        if (time <= 0)
        {
            int i = Random.Range(0, rock.Length);
            int s = Random.Range(0, spawn.Length);
            Instantiate(rock[i], spawn[s].transform.position, spawn[s].transform.rotation);
            time = Random.Range(minTime, maxTime);
        }
    }
}
