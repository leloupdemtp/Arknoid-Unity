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

            // reset le speed

            ballRB.velocity = Vector2.zero;

            // distance point impacte
            float distance = this.transform.position.x - collision.contacts[0].point.x;

            // envoie une force dans la direction appropriée
            ballRB.AddForce(new Vector2(Mathf.Sign(distance) * -Mathf.Abs(distance * 200), CS_BallManager.Instance.ballSpeed));

        }
    }

}
