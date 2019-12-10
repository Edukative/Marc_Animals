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
        if(other.tag == "Player")
        {
            PlayerController player = GetComponent<PlayerController>();
            player.health--;
            Debug.Log(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
