using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;
    float distTOPlayer;

    private void FixedUpdate()
    {
        distTOPlayer = Vector2.Distance(transform.position, player.position);
       


        if (distTOPlayer < 3f)
            if (Input.GetKeyDown(KeyCode.E))
            {
              gameManager.CompleteLevel();

            }
        return;
    }
     
}
