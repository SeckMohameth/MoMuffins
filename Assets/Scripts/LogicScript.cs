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
    public GameObject nextLevelScreen;
    public GameObject youWin;



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
            //Time.timeScale = 0; // pause the game

            DestroyAllMuffins();
            FindObjectOfType<PlayerMovement>().DisableMovement();
            FindObjectOfType<Spawner>().DisableSpawning();
            
            nextLevelScreen.SetActive(true); // display
            youWin.SetActive(true);


            //int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            //int nextLevelIndex = currentLevelIndex + 1;

            //if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
            //{
            //    SceneManager.LoadScene(nextLevelIndex); // Load the next level
            //}
            //else
            //{
            //    // Optionally, load the main menu or restart the game if there are no more levels
            //    SceneManager.LoadScene("MainMenu");
            //}
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
        //Time.timeScale = 1;

    }

    public void quitGame()
    {
        SceneManager.LoadScene("Main Menu");
      
    }


    public void DisableLogic()
    {
        this.enabled = false;
    }

    public void EnableLogic()
    {
        this.enabled = true;
    }



    public void gameOver()
    {
        DestroyAllMuffins();
       
        FindObjectOfType<PlayerMovement>().DisableMovement();
        FindObjectOfType<Spawner>().DisableSpawning();
        gameOverScreen.SetActive(true);
        
        
    }

    public void Win()
    {
        FindObjectOfType<PlayerMovement>().DisableMovement();
        FindObjectOfType<Spawner>().DisableSpawning();
        youWin.SetActive(true);
    }

    //public void NextLevel()
    //{

    //    FindObjectOfType<PlayerMovement>().DisableMovement();
    //    FindObjectOfType<Spawner>().DisableSpawning();
    //    nextLevelScreen.SetActive(true);
    
    //}


    public void LevelTwo()
    {
        SceneManager.LoadScene("level 2");
      

    }

    public void LevelThree()
    {
        SceneManager.LoadScene("level 3");
        

    }



    public void AboutDeveloper()
    {
        SceneManager.LoadScene("About The Developer");
        

    }



    public void buttonPressed()
    {
        Debug.Log("I'm working");
    }



    // Add a method to destroy all muffins
    public void DestroyAllMuffins()
    {
        // Find all game objects with FallingMuffins component and destroy them
        FallingMuffins[] allMuffins = FindObjectsOfType<FallingMuffins>();
        foreach (FallingMuffins muffin in allMuffins)
        {
            Destroy(muffin.gameObject);
        }
    }
}