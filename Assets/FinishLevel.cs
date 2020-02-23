using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene = "loadLevel";
   

 
    void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
            if (other.CompareTag("Player"))
            {

                SoundManagerScript.PlaySound("MDME_Victory_1_0");
                SceneManager.LoadScene(scene);


            }
            
       
      
        Debug.LogError("Enter");

    }
}