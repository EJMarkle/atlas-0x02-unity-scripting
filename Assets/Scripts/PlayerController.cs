using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private int score = 0;
    public int health = 5;

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

    
    void OnTriggerEnter(Collider other)
    {
        /// On collision with coin, increment player score and deactivate object
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;

            Debug.Log("Score: " + score);

            other.gameObject.SetActive(false);
        }

        /// If player collides with trap, decrement health
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
  
            Debug.Log("Health: " + health);
        }

        /// Win if collide with Goal
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
