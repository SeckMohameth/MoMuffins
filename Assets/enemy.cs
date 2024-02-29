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

            }

            Destroy(gameObject);
        }
    }
}
