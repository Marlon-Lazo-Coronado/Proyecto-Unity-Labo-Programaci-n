using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Alucard_Grav : Fighter//MonoBehaviour
{
    public float runSpeed=2; 

    public float jumpSpeed=3;

    //Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float  lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public GameObject sonidoEspada;
    public GameObject sonidoSalto;
    
    


    /*Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;*/
    //Nuevo



    /*void Start()
    {

        rb2D=GetComponent<Rigidbody2D>();

        //***********************
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //*****************************
    }*/



    void FixedUpdate()
    {
        //*************
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Punch());
            Instantiate(sonidoEspada);
        }

        isGuard = Input.GetKey(KeyCode.X);

        anim.SetBool("IsGuard", isGuard);
        //************

            if (Input.GetKey("d") || Input.GetKey("right")){
           
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);

            spriteRenderer.flipX = false;
            animator.SetBool("Alucard_quieto", false);

    }

    else if (Input.GetKey("a") || Input.GetKey("left")){

            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);

            spriteRenderer.flipX = true;
            animator.SetBool("Alucard_quieto", false);
           

        }

    else 
    {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Alucard_quieto", true);

        }

    if (Input.GetKey("space") && CheckGround.isGrounded){

            Instantiate(sonidoSalto);

            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
    }

    if (CheckGround.isGrounded == false)
        {
           animator.SetBool("Alucard_volar", true);
           animator.SetBool("Alucard_quieto", false);
        }
    if (CheckGround.isGrounded == true)
        {
        animator.SetBool("Alucard_volar", false);
        }






        if (betterJump){

        if (rb2D.velocity.y < 0){
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }

        if (rb2D.velocity.y > 0 && !Input.GetKey("space")){
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }


    }



    }
}
