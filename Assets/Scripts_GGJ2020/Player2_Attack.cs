using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Attack : MonoBehaviour
{
    private AudioSource source;
    private float timeBtAttack;
    public float startTimeBtAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsObjects;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent < AudioSource>();
    }

    private void Update()
    {
        if (timeBtAttack <= 0)
        {
            //Entonces atacamos
            if (Input.GetKey(KeyCode.F))
            {
                
                anim.SetBool("isAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0 , whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    SoundManagerScript.PlaySound("MDSFX_PlayerHitHeavy_1_0");
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    
                }

                Collider2D[] objectsToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsObjects);
                for (int i = 0; i < objectsToDamage.Length; i++)
                {
                    SoundManagerScript.PlaySound("MDSFX_PlayerHitLight_1_0");
                    objectsToDamage[i].GetComponent<Object>().TakeDamage(damage);

                }
            }
            timeBtAttack = startTimeBtAttack;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            timeBtAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX,attackRangeY,1));
    }
}
