using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthySnacks : MonoBehaviour
{

    public LogicScript logic;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if(logic == null)
            {
                logic = FindAnyObjectByType<LogicScript>();
            }

            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                logic.lostWeight(playerMovement);
            }

            Destroy(gameObject);
        }
    }
}
