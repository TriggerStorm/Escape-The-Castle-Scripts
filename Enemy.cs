using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public GameManager gameManager;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damaged(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var delay = 1;
        
        GetComponent<EnemysAgroRange>().speed = 0;
        Debug.Log("Enemy died!");
        // die animation
        animator.SetBool("IsDead", true);
        //desable enemy
        GetComponent<CapsuleCollider2D>().enabled = false;
        gameManager.addScore(5);

        this.enabled = false;
        Destroy(gameObject,delay);
    }
}
