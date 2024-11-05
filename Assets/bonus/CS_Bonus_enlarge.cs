using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Bonus_enlarge : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "paddle")
        {
            collider.gameObject.transform.localScale = new Vector3(1.7f,1,1);

        }
        if (collider.tag == "paddle" || collider.tag == "wall")
        {
            Destroy(this.gameObject);

        }

    }
}