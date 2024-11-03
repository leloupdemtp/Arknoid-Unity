using UnityEditor;
using UnityEngine;



public class CS_PlayerController : MonoBehaviour
{
    #region Singleton

    private static CS_PlayerController instance;

    public static CS_PlayerController Instance => instance;

    private void Awake()
        
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    public float speed = 1f;
  
    public Rigidbody2D rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
    }

    private void Update()
    {
        
        Moove();
    }



    public void Moove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.position += new Vector3(0.1f,0,0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.position -= new Vector3(0.1f, 0, 0) * speed * Time.deltaTime;
        }

    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = collision.contacts[0].point;
            Vector3 Player = this.gameObject.transform.position;
            Vector3 paddleCenter = new Vector3(Player.x, Player.y);

            ballRB.velocity = Vector2.zero;

            float distance = paddleCenter.x - hitPoint.x;

            if (hitPoint.x < paddleCenter.x)
            {
                ballRB.AddForce( new Vector2(-(Mathf.Abs(distance * 200)), CS_BallManager.Instance.ballSpeed));
            }
            else
            {
                ballRB.AddForce (new Vector2(Mathf.Abs(distance * 200), CS_BallManager.Instance.ballSpeed));
            }
        }
    }

}
