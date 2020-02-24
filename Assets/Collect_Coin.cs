using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }
    }
    
    //if (other.CompareTag("Player"))
    // {

    //  }

    //Debug.LogError("Enter");


}