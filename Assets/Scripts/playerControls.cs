using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6; // Movement speed of the player
    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    private float movement; // The current movement direction (-1 for left, 1 for right)
    public float baseSpeed = 6; // The base speed of the player


    float screenHalfWidthInWorldUnits;

    public bool moIsAlive = true;

    // reference to the LogicScript component
    public LogicScript logicScript;


    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;

        logicScript = FindObjectOfType<LogicScript>();

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


        HealthManager healthManager = FindObjectOfType<HealthManager>();



        // GAME OVER
        if (healthManager.health <= 0)
        {
            //handle game over
            Debug.Log("Health is 0 or less, game over should trigger.");

            logicScript.gameOver();
            moIsAlive = false;
        }

    }

    public void AdjustSpeed()
    {
        // Call the method to adjust the player's speed based on weight
        logicScript.UpdatePlayerSpeed(this);
    }

}
