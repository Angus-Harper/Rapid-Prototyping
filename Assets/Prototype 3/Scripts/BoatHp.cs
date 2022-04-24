using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BoatHp : MonoBehaviour
{
    public int maxHp = 20;
    public int currentHp;

    public HealthBar healthbar;
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
            SceneManager.LoadScene("P3Lost");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            currentHp--;
            healthbar.SetHealth(currentHp);
            Camera.main.DOShakePosition(0.5f * 2, 1);
        }
    }
}
