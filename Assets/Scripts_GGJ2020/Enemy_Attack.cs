using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    private float timeBtAttack;
    public float startTimeBtAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    public float playerDistant;

    private Animator anim;

    //Player
    private Transform playerTarget;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (timeBtAttack <= 0)
        {
            //Entonces atacamos
            if (Vector2.Distance(transform.position, playerTarget.position) < playerDistant)
            {

                SoundManagerScript.PlaySound("MDSFX_FoeHit_1_0");
                anim.SetTrigger("isAttacking");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Player1_Controller>().TakeDamage(damage);

                }

               
            }
            timeBtAttack = startTimeBtAttack;
        }
        else
        {
            //anim.SetBool("isAttacking", false);
            timeBtAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
