using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParalaxController : MonoBehaviour
{
    [Range(0f, 0.20f)]
    public float parallaxSpeed = 0.02f;
    public RawImage background1;
    public RawImage background2;
    public RawImage background3;
    public RawImage background4;


    private int state;

    // Start is called before the first frame update
    void Start()
    {
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        if (Input.anyKey)
        {
            state = 1;
        }

        if(state == 1)
        {
            background1.uvRect = new Rect(background1.uvRect.x + (finalSpeed * 5), 0f, 1f, 1f);
            background2.uvRect = new Rect(background2.uvRect.x + (finalSpeed * 3), 0f, 1f, 1f);
            background3.uvRect = new Rect(background3.uvRect.x + (finalSpeed * 4), 0f, 1f, 1f);
            background4.uvRect = new Rect(background4.uvRect.x + (finalSpeed * 5), 0f, 1f, 1f);
        }
        
        
    }
}
