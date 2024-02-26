using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMuffins : MonoBehaviour
{

    float speed = 4;
    float deadZone = -8;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
