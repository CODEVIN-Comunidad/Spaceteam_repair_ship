using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] startingPositioins;
    public GameObject[] rooms;

    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositioins.Length);
        transform.position = startingPositioins[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

    }

    
}
