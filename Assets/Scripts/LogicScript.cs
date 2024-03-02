using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreNumber;

    public int playerWeight;
    public TMP_Text weightNumber;

    public GameObject gameOverScreen;




    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreNumber.text = playerScore.ToString();

        if (playerScore % 4 == 0)
        {
            addWeight();
        }

        if (playerScore >= 20)
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            int nextLevelIndex = currentLevelIndex + 1;

            if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextLevelIndex); // Load the next level
            }
            else
            {
                // Optionally, load the main menu or restart the game if there are no more levels
                SceneManager.LoadScene("MainMenu");
            }
        }

    }

    public void decreaseWeightScore()
    {
        playerWeight = Mathf.Max(playerWeight - 1, 0);
        weightNumber.text = playerWeight.ToString();

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

    //===================== PLAYER SPEED MOVEMENT =======================================
    //==================================================================================
    public void UpdatePlayerSpeed(PlayerMovement playerMovement, bool isWeightLoss= false)
    {
        float speedMultiplier;
        if (isWeightLoss)
        {
            // Increase speed due to weight loss
            speedMultiplier = 1 + (0.05f * (playerWeight * 0.02f)); // Example: increase speed more significantly for weight loss
        }
        else
        {
            // Regular speed adjustment based on current weight
            speedMultiplier = 1 - (playerWeight * 0.02f);
        }
        speedMultiplier = Mathf.Max(speedMultiplier, 0.1f); // Ensure minimum speed limit
        playerMovement.speed = playerMovement.baseSpeed * speedMultiplier; // Adjust baseSpeed accordingly
    }

    public void lostWeight(PlayerMovement playerMovement)
    {
        int weightLossAmount = 1;

        // making sure it doesn't go pass 0
        playerWeight = Mathf.Max(playerWeight - weightLossAmount, 0);
        weightNumber.text = playerWeight.ToString();


        UpdatePlayerSpeed(playerMovement, true);
    }
    //==================================================================================

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}