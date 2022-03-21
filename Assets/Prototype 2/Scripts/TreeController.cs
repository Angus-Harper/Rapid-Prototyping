using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreeController : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;

    public HealthBar healthbar;

    public SpawnEnemy spawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthbar.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            SceneManager.LoadScene("Title");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHp--;
            healthbar.SetHealth(currentHp);
            spawnEnemy.Kill(collision.gameObject);
        }
    }
}
