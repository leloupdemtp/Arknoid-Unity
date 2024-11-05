using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CS_Bonus_Multiball : MonoBehaviour
{
    
    public Rigidbody2D Rigidbody;
    private void OnTriggerEnter2D(Collider2D collider)
    {
       var position = new Vector3(CS_BallManager.firstBall.transform.position.x + 0.1f, CS_BallManager.firstBall.transform.position.y+0.2f, 10);
       var position2 = new Vector3(CS_BallManager.firstBall.transform.position.x + 0.1f, CS_BallManager.firstBall.transform.position.y + 0.2f, 10);
        if (collider.tag == "paddle")
        {

            Instantiate(CS_BallManager.ball.gameObject, position, Quaternion.identity);
            Instantiate(CS_BallManager.ball.gameObject, position2, Quaternion.identity);



        }
       if (collider.tag =="paddle" || collider.tag == "wall")
        {
            Destroy(this.gameObject);

        }
        
    }

    
}
