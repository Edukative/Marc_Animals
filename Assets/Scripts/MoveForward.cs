using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move Forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Destroy if is too far
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            print("it works");
        }

        // Destroy if it alredy passed beyond the player movement
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            print("die animal");
        }
    }
}
