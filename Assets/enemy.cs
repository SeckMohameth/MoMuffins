using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public LogicScript logic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            HealthManager healthManager = FindObjectOfType<HealthManager>();
            if(healthManager != null && healthManager.health > 0)
            {
                healthManager.health--; // decrease the health
                //if(healthManager.health <= 0)
                //{
                //    //handle game over
                //    Debug.Log("Health is 0 or less, game over should trigger.");

                //    logic.gameOver();
                //}
            }

            Destroy(gameObject);
        }
    }
}
