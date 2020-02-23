using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene = "loadLevel";
    public float delay = 440;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }    
        IEnumerator LoadLevelAfterDelay(float delay)
        {
            SoundManagerScript.PlaySound("MDME_Victory_1_0");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(scene);
        }

            
            
        //if (other.CompareTag("Player"))
           // {
            
          //  }
      
        //Debug.LogError("Enter");

    
}