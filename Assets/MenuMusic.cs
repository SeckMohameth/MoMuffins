using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MenuMusic : MonoBehaviour
{
    public static MenuMusic instance;
 
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
}
 