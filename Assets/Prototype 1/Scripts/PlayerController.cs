using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 15.0f;
    public float speed = 5.0f;
    public float jumpHeight = 6;
    public float grv = 9.81f;
    public bool hasPowerUp;
    public bool hasFirePowerUp;
    public bool start = false;
    public bool isGrounded;
    public float cointP;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask layer;
    Vector3 jump;
    public GameObject powerUpIndicator;
    public GameObject firePowerUpIndicator;
    public GameObject playerIndicator;
    public GameObject spawnManager;
    public GameObject coin;
    public GameObject tP;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layer);

        Vector3 playerPos = transform.position + new Vector3(0, -0.5f, 0);
        float forwardInpiut = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.right * speed * forwardInpiut);
        powerUpIndicator.transform.position = playerPos;
        firePowerUpIndicator.transform.position = playerPos;
        playerIndicator.transform.position = playerPos;

        if (transform.position.y < -100)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(jump * jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            powerUpIndicator.gameObject.SetActive(true);
        }
        if (other.CompareTag("FirePowerUp"))
        {
            hasFirePowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            firePowerUpIndicator.gameObject.SetActive(true);
        }
        if (other.CompareTag("Coin"))
        {
            cointP++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("TP"))
        {
            transform.position = new Vector3(-102, 47, 0);
        }
        if (other.CompareTag("Bounce"))
        {
            playerRb.AddForce(jump * 27, ForceMode.Impulse);
        }
    }
    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        hasFirePowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
        firePowerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRidgidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("collided with " + collision.gameObject.name + "with poserup set to " + hasPowerUp);
            enemyRidgidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Enemy") && hasFirePowerUp)
        {
            Destroy(collision.gameObject);
        }
    }

    private Vector3 GSpawnPosition()  // Vector3 can replace Voids only if we "return" a value
    {
        Vector3 randomPos = new Vector3(-1, 0.15f, 8);
        return randomPos;
    }
}
