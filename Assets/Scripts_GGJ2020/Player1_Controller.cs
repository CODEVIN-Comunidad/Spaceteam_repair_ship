using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{
    //Control de movimiento
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    //Flip de personaje
    private bool facingRight = true;

    //Comprobar si el jugador toca el suelo.
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Saltos
    private int extraJumps;
    public int extraJumpsValue;

    //Vida
    public int health;

    public string script;


    private Animator anim;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
   
    }

    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            anim.SetBool("isWalking", true);
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            anim.SetBool("isWalking", true);
            Flip();
        }


    }

    void Update()
    {
        
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            
            anim.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {

            anim.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
       
        //Muerte del jugador
        if (health <= 0)
        {
            GameObject.Find("Trevor (Player1)").GetComponent<Player1_Attack>().enabled = false;
            GetComponent<Player1_Controller>().enabled = false;
            SoundManagerScript.PlaySound("MDSFX_PlayerDown_1_0");
            anim.SetBool("isDeath", true);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //Vida
    public void TakeDamage(int damage)
    {

       
        health -= damage;
        
    }

}
