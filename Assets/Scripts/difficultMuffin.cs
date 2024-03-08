using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultMuffin : MonoBehaviour
{
    public Vector3 scaleIncrease = new Vector3(1.5f, 1.5f, 1.5f); // Increase in size
    public float fallSpeed = 4.0f; // Speed of falling
    public float angleRange = 45.0f; // Range of angles to fall at, from -angleRange to +angleRange degrees

    // Start is called before the first frame update
    void Start()
    {
        // Adjust the size of the muffin
        transform.localScale = scaleIncrease;

        // Set a random rotation within the specified range around the Z axis
        float randomAngle = Random.Range(-angleRange, angleRange);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the muffin straight down at the angle it's rotated at
        Vector3 fallDirection = transform.up * -1; // The up direction rotated by the angle will be the fall direction
        transform.Translate(fallDirection * fallSpeed * Time.deltaTime, Space.World);
    }

}
