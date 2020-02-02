using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int healthObject;
    //private float speed;
    //public float speedSet;
    //private float dazedTime;
    //public float startDazedTime;

    public GameObject bloodEffect;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);

    }

    void Update()
    {
        //if (dazedTime <= 0)
        //{
        //    //anim.SetBool("isHurt", false);
        //    speed = speedSet;
        //}
        //else
        //{
        //    //anim.SetBool("isHurt", true);
        //    speed = 0;
        //    dazedTime -= Time.deltaTime;
        //}

        if (healthObject <= 0)
        {
            Destroy(gameObject);
        }

       // transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {

        //dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        healthObject -= damage;
        Debug.Log("damage Taken");
    }
}
