using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("level 1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    
}
