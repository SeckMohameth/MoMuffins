using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchMuffin : MonoBehaviour
{
    
    public LogicScript logic;
    GameObject muffin;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
        Destroy(muffin);
    }
}
