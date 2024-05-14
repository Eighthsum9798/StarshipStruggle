using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement speed variables
    public float movspeed; // Movement speed of the player
    float speedX, speedY; // Horizontal and vertical speed components
    Rigidbody2D rb; // Reference to the Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        speedX = Input.GetAxisRaw("Horizontal") * movspeed; // Horizontal movement speed
        speedY = Input.GetAxisRaw("Vertical") * movspeed; // Vertical movement speed
        // Set the velocity of the player's Rigidbody
        rb.velocity = new Vector2(speedX, speedY); // Set the velocity using speedX and speedY
    }
}
