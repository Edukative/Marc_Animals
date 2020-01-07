using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.tag == "Player" && this.tag == "Animal")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.LoseHP();
            Debug.Log(other.gameObject);
            Destroy(gameObject);
        }
        else if (this.tag != "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
