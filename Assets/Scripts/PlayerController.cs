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

    public bool isGameOver = false; // if the player is dead
    public bool restart = false; // the game "restarts"
    public int hp; //Player's Health

    //UI
    public SpriteRenderer hp1;
    public SpriteRenderer hp2;
    public SpriteRenderer hp3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        hp1 = canvas.transform.GetChild(0).GetComponent<SpriteRenderer>();
        hp2 = canvas.transform.GetChild(1).GetComponent<SpriteRenderer>();
        hp3 = canvas.transform.GetChild(2).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) // if it's not Game Over, keep playing!
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
        else if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            isGameOver = false;
            hp = 4;
            LoseHP();
            restart = true;
        }
        

    }

   public void LoseHP ()
    {
        if (hp > 0)
        {
            hp--; // same as h
            switch (hp) // hp cases
            {
                case 2: hp3.enabled = false; // if hp is 2
                    break;
                case 1: hp2.enabled = false; // if hp is 1
                    break;
                case 0: hp1.enabled = false; // if hp is 0
                    isGameOver = true;
                        break;
                default: hp3.enabled = true; // default case that is necessary
                         hp2.enabled = true;
                         hp1.enabled = true;
                    break;
            }
        }
    }
}
