using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float xRange = 20.0f; // Range limit that the player can move
    public GameObject projectile;
    private Vector3 projectileOffset;

    public int health; //Player's Health

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
            projectileOffset = transform.position; // get the current position
            projectileOffset.z = 1;
            Instantiate(projectile, projectileOffset, projectile.transform.rotation);
        }
        
        // Move left/right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Limit the movement of the player
        if (transform.position.x < -xRange) // too far to the left
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange) //too far to the right
        {
            // Capped at the same position
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

    }
}
