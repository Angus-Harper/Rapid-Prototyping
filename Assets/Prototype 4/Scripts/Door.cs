using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public int doorNumber;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        doorNumber = Random.Range(-100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = doorNumber.ToString();

        if (doorNumber == 0)
        {
            Destroy(gameObject);
        }
    }
}
