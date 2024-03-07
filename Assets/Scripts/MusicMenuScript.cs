using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMenuScript : MonoBehaviour
{
    public static MusicMenuScript instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (SceneManager.GetActiveScene().name == "level 1" || SceneManager.GetActiveScene().name == "level 2" || SceneManager.GetActiveScene().name == "level 3")
            instance.GetComponent<AudioSource>().Pause();
        //BGmusic.instance.GetComponent<AudioSource>().Play();

    }
}
