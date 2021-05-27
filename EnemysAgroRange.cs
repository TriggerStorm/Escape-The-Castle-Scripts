using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysAgroRange : MonoBehaviour
{
    
    public Transform player;
    public float agroRange = 1f;
    public float speed;
    public Animator animator;
    float horizontalMove = 0f;
    bool ismoving = false;
    public float attackRange = 1f;
    float distTOPlayer;
    float attackRate;

    float nextAttackTime = 0f;
    Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackRate = GetComponent<EnemyAttack>().attackRate;
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
         distTOPlayer = Vector2.Distance(transform.position, player.position);
       // Debug.Log("distTOPlayer" + distTOPlayer);

        
        if (distTOPlayer < agroRange)
        {
            ChasePlayer();
            animator.SetBool("IsMoving", ismoving);
           
        }
        else
        {
            StopChasingPlayer();
           // Debug.Log("stop chase");
        }
    }

    

    private void StopChasingPlayer()
    {
        rb.velocity = Vector2.zero;
        horizontalMove = 0;
        
        ismoving = false;
        animator.SetBool("IsMoving", ismoving);
    }


           


        private void ChasePlayer()
    {
        
            if (transform.position.x <= player.position.x)
        {
            // Debug.Log("moving right");
            // move right
            if ( distTOPlayer < attackRange)
            {
                rb.velocity = Vector2.zero;
                ismoving = false;
                animator.SetBool("IsMoving", ismoving);
                return;
            }
            horizontalMove = 1;
            ismoving = true;
            rb.velocity = transform.right * speed;
            transform.localScale = new Vector2(1, 1);
        }
        // move left
        else 
        {
            if (distTOPlayer < attackRange)
            {
                rb.velocity = Vector2.zero;
                ismoving = false;
                animator.SetBool("IsMoving", ismoving);
                return;
            }
            // Debug.Log("moving left");
            ismoving = true;
            horizontalMove = 1;
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
