﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float xRange = 10.0f; // Range limit that the player can move
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) // if you press "space"
        {
            // Shoot a food prefab
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
        
        // Move left/right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Limit the movement of the player
        if (transform.position.x < -xRange) // too far to the left
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange) //too far to the right
        {
            // Capped at the same position
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

    }
}
