using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreNumber;

    public int playerWeight;
    public TMP_Text weightNumber;


    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreNumber.text = playerScore.ToString();

        if(playerScore % 4 == 0)
        {
            addWeight();
        }

    }

    public void addWeight()
    {
        playerWeight = playerWeight + 2;
        weightNumber.text = playerWeight.ToString();

        //find player in scene and adjust speed
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.AdjustSpeed();
        }
    }


    public void UpdatePlayerSpeed(PlayerMovement playerMovement)
    {
        // Calculate the new speed multiplier based on the player's weight
        float speedMultiplier = 1 - (playerWeight * 0.02f);
        // Make sure the speed doesn't become negative or zero
        speedMultiplier = Mathf.Max(speedMultiplier, 0.1f);
        // Apply the speed multiplier to the player's speed
        playerMovement.speed *= speedMultiplier;
    }

}
