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
    public GameObject oBworld;
    public WorldObject world;
    public float lifeTime = 20;
    public GameObject audio;
    public AudioSource audioSource;
    public AudioClip pop;
    // Start is called before the first frame update
    void Start()
    {
        oBDoor = GameObject.Find("Door");
        door = oBDoor.GetComponent<Door>();
        audio = GameObject.Find("Audio");
        audioSource = audio.GetComponent<AudioSource>();
        oBworld = GameObject.Find("WorldObject");
        world = oBworld.GetComponent<WorldObject>();
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        number = Random.Range(0, 100);
    }
    // Update is called once per frame
    void Update()
    {
        if(door.doorNumber == door.doorTarget)
        {
            world.won = true;
        }
        text.text = number.ToString();
        lifeTime = lifeTime - 1 * Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock")
        {
            audioSource.PlayOneShot(pop);
            if (world.ammoType == 1)
            {
                door.doorNumber += number;
            }
            else if (world.ammoType == 2)
            {
                door.doorNumber -= number;
            }
            else if (world.ammoType == 3)
            {
                door.doorNumber *= number;
            }
            else if (world.ammoType == 4)
            {
                door.doorNumber /= number;
            }
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
