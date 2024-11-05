using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CS_Bonus_OneUp : MonoBehaviour
{
    
    public Rigidbody2D Rigidbody;
    private void OnTriggerEnter2D(Collider2D collider)
    {
      
        if (collider.tag == "paddle")
        {
            CS_GameManager.Lives++;


        }
       if (collider.tag =="paddle" || collider.tag == "wall")
        {
            Destroy(this.gameObject);

        }
        
    }

    
}
