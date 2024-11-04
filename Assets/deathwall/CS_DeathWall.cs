using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            CS_ball ball = collision.GetComponent<CS_ball>();
            CS_BallManager.Instance.Balls.Remove(ball);
            ball.Delete(); 
        }
    }
}
