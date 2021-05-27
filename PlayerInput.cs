using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public PlayerMoveMent controler;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool Jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void onLanding ()
    {
        animator.SetBool("IsJumping", false);
    }
    public void onCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

  

    private void FixedUpdate()
    {
        // move our character
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, Jump);
        Jump = false;

    }
   
}
