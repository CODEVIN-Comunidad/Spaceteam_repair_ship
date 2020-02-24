using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//El enemigo se mantendra en su plataforma.
public class Enemy_Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;
    public LayerMask whatIsGround;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, whatIsGround);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}
