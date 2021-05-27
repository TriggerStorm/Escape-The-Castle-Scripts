using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Transform castPoint;
    public GameObject fireBall;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public float castCD = 5f;
    float nextCastTime = 0f;


    // Update is called once per frame
    void  Update()
    {
        if (Time.time >= nextCastTime)
        {
            if(GetComponent<PlayerStats>().currentMana >= 10)
            { 
            if (Input.GetKeyDown(KeyCode.F))
            {
                Cast();
                nextCastTime = Time.time + castCD;
            }
            }
        }

            if (Time.time >= nextAttackTime)
        {
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    private void Cast()
    {
        // play casting animatoin
        animator.SetTrigger("Casting");

        Instantiate(fireBall, castPoint.position, castPoint.rotation);
        GetComponent<PlayerStats>().useMana(10);
        


    }

    private void Attack()
    {
        // play attack animation
       
            animator.SetTrigger("Attack");
       
    // hit detection
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //dmg cal
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Damaged(attackDamage);
        }

       
       
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
