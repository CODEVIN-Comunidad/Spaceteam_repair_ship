using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    private float timeBtAttack;
    public float startTimeBtAttack;

    public Transform attackPoint;
    public LayerMask whatIsPlayer;

    public float attackRange = 0.5f;
    //public float attackRangeX;
    //public float attackRangeY;
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

                //Collider2D[] PlayerToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsPlayer);
                Collider2D[] PlayerToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsPlayer);
                for (int i = 0; i < PlayerToDamage.Length; i++)
                {
                    SoundManagerScript.PlaySound("MDSFX_FoeHit_1_0");
                    anim.SetTrigger("isAttacking");
                    PlayerToDamage[i].GetComponent<Player1_Controller>().TakeDamage(damage);

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
        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
