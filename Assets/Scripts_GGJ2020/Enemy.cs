using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private float speed;
    public float speedSet;
    private float dazedTime;
    public float startDazedTime;

    private Animator anim;
    public GameObject bloodEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);

    }

    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = speedSet;
        }
        else
        {
            speed = 0.0f;
            dazedTime -= Time.deltaTime;
        }
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage Taken");
    }
}
