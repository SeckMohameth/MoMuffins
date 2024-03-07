using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    public GameObject fallingMuffinPrefab;
    public float secondsBetweenSpawns = 5;
    float nextSpawnTime;

    Vector2 screenHalfSizeWorldUnits;
  


    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

      
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + .5f);
            Instantiate(fallingMuffinPrefab, spawnPosition, Quaternion.identity);
        }

    }


    public void DisableSpawning()
    {
        //this.enabled = false;
        //nextSpawnTime = 900;

        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            spawner.enabled = false; // This disables the Spawner script
                                     // If you have a coroutine for spawning, you might need to stop it as well
                                     // spawner.StopAllCoroutines(); // Uncomment if needed
        }
    }

    public void EnableSpawning()
    {
        this.enabled = true;
    }


}
