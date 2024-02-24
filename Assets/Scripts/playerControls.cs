using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    private float movement; // The current movement direction (-1 for left, 1 for right)



    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        // Read the horizontal input (left/right arrows or A/D keys)
        movement = Input.GetAxis("Horizontal");


    }





    // FixedUpdate is called at a fixed interval and is used for physics updates
    void FixedUpdate()
    {
        // Apply the movement to the player's Rigidbody2D component
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);

    }
}
