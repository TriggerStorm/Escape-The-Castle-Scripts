using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public Transform player;
    public Animator animator;
    public float attackRange = 1f;
    public Transform attackPoint;

    float nextAttackTime = 0f;
    public float attackRate = 2f;
    public int attackDamage = 15;
    float distTOPlayer;
    Vector2 dummy = new Vector2();
    bool isAttacking = false;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        distTOPlayer = Vector2.Distance(transform.position, player.position);

        if (Time.time >= nextAttackTime) { 
            if (distTOPlayer < attackRange)
        {
            
            Invoke("Attack", 1f);
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
        }
    }

    private void Attack()
    {
 
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayer);

            //dmg cal

            hitEnemies[1].GetComponent<PlayerStats>().Damaged(attackDamage);
 
    }
}
