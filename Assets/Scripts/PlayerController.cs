using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private int score = 0;

    /// Preload get rigidbody component 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// X and Y axis movement
    void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xMovement, 0f, yMovement) * speed;
        rb.velocity = movement;
    }

    /// On collision with coin, increment player score and deactivate object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;

            Debug.Log("Score: " + score);

            other.gameObject.SetActive(false);
        }
    }
}
