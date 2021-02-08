using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayZone : MonoBehaviour
{
   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController2D playerController2D = collision.GetComponent<PlayerController2D>();
            
            if (playerController2D != null)
            {
                playerController2D.onLayZone = true;
                
            }
        }


    }

  
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController2D playerController2D = collision.GetComponent<PlayerController2D>();
        if (playerController2D != null)
        {
            playerController2D.onLayZone = false;
        }
    }

}
