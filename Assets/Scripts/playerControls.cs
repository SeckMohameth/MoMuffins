using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6; // Movement speed of the player
    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    private float movement; // The current movement direction (-1 for left, 1 for right)

    float screenHalfWidthInWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;


    }

    // Update is called once per frame
    void Update()
    {
        // Read the horizontal input (left/right arrows or A/D keys)
        float movement = Input.GetAxis("Horizontal");
        float velocity = movement * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if(transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

    }
}
