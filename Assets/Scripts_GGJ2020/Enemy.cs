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
            anim.SetTrigger("isHurt");
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        
        dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("Enemy died!");

        SoundManagerScript.PlaySound("MDSFX_FoeDown_1_0");

        anim.SetBool("isRunning", false);
        anim.SetBool("isDead", true);

        GetComponent<Enemy_Attack>().enabled = false;
        GetComponent<Enemy_Patrol>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
