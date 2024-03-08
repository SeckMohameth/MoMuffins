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





    // touch screen
    private bool moveLeft = false;
    private bool moveRight = false;






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


        //========================TOUCH==========================================


        // Touch control overrides
        if (moveLeft)
        {
            movement = -1;
        }
        else if (moveRight)
        {
            movement = 1;
        }
        else
        {
            // Only use keyboard input if no touch input is active
            movement = 0;
        }
       


        // Read the horizontal input (left/right arrows or A/D keys)
        //float movement = Input.GetAxis("Horizontal");
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

            logicScript.gameOver();
            moIsAlive = false;
        }


    }


    // Button control methods
    public void OnLeftButtonDown()
    {
        moveLeft = true;
        Debug.Log("pressed down");
    }

    public void OnLeftButtonUp()
    {
        moveLeft = false;
        // If the right button isn't held down, reset movement to 0
        if (!moveRight)
        {
            movement = 0;
        }
    }

    public void OnRightButtonDown()
    {
        moveRight = true;
    }

    public void OnRightButtonUp()
    {
        moveRight = false;
        // If the left button isn't held down, reset movement to 0
        if (!moveLeft)
        {
            movement = 0;
        }
    }






    public void AdjustSpeed()
    {
        // Call the method to adjust the player's speed based on weight
        logicScript.UpdatePlayerSpeed(this);
    }


    public void DisableMovement()
    {
        this.enabled = false;
    }

    public void EnableMovement()
    {
        this.enabled = true;
    }
}
