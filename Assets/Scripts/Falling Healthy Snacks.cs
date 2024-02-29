using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHealthySnacks : MonoBehaviour
{

    float speed = 4;
    float deadZone = -8;

    public LogicScript logic;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);


        if (transform.position.y < deadZone)
        {
            Debug.Log("muffin deleted");
            Destroy(gameObject);


        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("player"))
        {
            logic.decreaseWeightScore();
            Destroy(gameObject);
        }

    }


}
