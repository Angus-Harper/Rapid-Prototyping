using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balloon : MonoBehaviour
{
    public int number;
    public TextMeshPro text;
    public GameObject oBDoor;
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        oBDoor = GameObject.Find("Door");
        door = oBDoor.GetComponent<Door>();
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        number = Random.Range(-100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = number.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock")
        {
            door.doorNumber += number;
            Destroy(gameObject);
        }
    }
}
