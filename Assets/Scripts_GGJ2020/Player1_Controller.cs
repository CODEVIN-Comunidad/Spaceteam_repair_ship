using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{
    private AudioSource source;

    //Control de Jugador
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode action;
    
    //Control de movimiento
    public float moveSpeed;
    public float jumpForce;
    //private float moveInput;

    private Rigidbody2D theRB;

    //Comprobar si el jugador toca el suelo.
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask objectsLayers;
    
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    
    private bool isGrounded;
    
    //Saltos
    private int extraJumps;
    public int extraJumpsValue;

    //Vida
    public int health;

    //Vida para Healthbar
    public LifeBar healthBar;

    public string script;

    private Animator anim;


    void Start()
    {
        healthBar.SetMaxHealt(health);
        
        extraJumps = extraJumpsValue;
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
    }
    void Update()
    {

        //----Move----///
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        //----Flip----///
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        ///----End Move----///

        //----Jump----///
       
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(jump) && extraJumps > 0)
        {

            theRB.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(jump) && extraJumps == 0 && isGrounded == true)
        {
            theRB.velocity = Vector2.up * jumpForce;
        }
        anim.SetBool("Grounded", isGrounded);
        //----End Jump----//

        //----Action----///
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(action))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        //----End Action----//

        //Muerte del jugador
        

    }


    //Vida
    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, objectsLayers);

        foreach (Collider2D objects in hitObjects)
        {
            SoundManagerScript.PlaySound("MDSFX_PlayerHitLight_1_0");
            objects.GetComponent<Object>().TakeDamage(attackDamage);
        }

        foreach (Collider2D enemy in hitEnemies)
        {
            SoundManagerScript.PlaySound("MDSFX_PlayerHitHeavy_1_0");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SoundManagerScript.PlaySound("MDSFX_PlayerDown_1_0");
        anim.SetBool("isDeath", true);

        this.enabled = false;
        //GameObject.Find("Trevor (Player1)").GetComponent<Player1_Attack>().enabled = false;
        //GetComponent<Player1_Controller>().enabled = false;
    }

}
