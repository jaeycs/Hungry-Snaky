using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Food")
        {
            // add another tail

            // destory food
            Destroy(other.gameObject);
            
        } else
        {
            Debug.Log("DEAD");
        }
    }

}
