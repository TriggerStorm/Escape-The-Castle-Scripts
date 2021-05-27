using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;

    private bool invisframes = false;

    public int maxHealth = 200;
    int currentHealth;
    public HeartBar healthBar;
    public ManaBar mbar;
    public int maxMana = 30;
    public int currentMana;
    public int manaRegen = 3;

    float nextManaTic = 0f;
    float regenTime = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        mbar.SetMaxMana(maxMana);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 

    }

    private void FixedUpdate()
    {
        if (Time.time >= nextManaTic)
        {
            regenMana();
            nextManaTic = Time.time + regenTime;
        }
    }

    public void Damaged(int damage)
    {
        if (invisframes) return;
     
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
        invisframes = true;
        Invoke("ResetInvisframes", 0.5f);
    }

    private void ResetInvisframes()
    {
        invisframes = false;
    }

    private void Die()
    {
        // die animation
        animator.SetBool("IsDead", true);

        gameManager.EndGame();
       
    }

    public void useMana(int mana)
    {
        currentMana -= mana;
        mbar.setMana(currentMana);
    }
    public void regenMana()
    {
        currentMana += manaRegen;
        mbar.setMana(currentMana);
    }
}
