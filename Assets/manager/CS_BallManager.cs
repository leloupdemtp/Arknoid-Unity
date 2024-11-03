using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BallManager : MonoBehaviour
{
    #region Singleton

    private static CS_BallManager instance;

    public static CS_BallManager Instance => instance;

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

    [SerializeField] private CS_ball prefabBall;
    private CS_ball firstBall;
    private Rigidbody2D firstBallRB;

    public float ballSpeed = 100f;
    
    public List<CS_ball> Balls {  get;  set; }
    public Rigidbody2D Player;
     

    private void Start()
    {
        InitialisationBall();
    }
    private void Update()
    {
       if (!CS_GameManager.Instance.IsGameStarted)
        {
            // garder la ball sur la raquette au bon endroit
            Vector3 paddlePosition = Player.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + 0.5f, 0);
            firstBall.transform.position = ballPosition;

            if (Input.GetMouseButtonDown(0))
            {
                firstBallRB.isKinematic = false;
                firstBallRB.AddForce(new Vector2(0, ballSpeed));
                CS_GameManager.Instance.IsGameStarted = true;
            }
        }

       
    }




    //set la position en debut de jeu
    private void InitialisationBall()
    {
        Vector3 paddlePosition = Player.transform.position; 
        Vector3 startingPosition = new Vector3(paddlePosition.x , paddlePosition.y + 0.5f, 0);
        firstBall = Instantiate(prefabBall, startingPosition, Quaternion.identity);
        firstBallRB = firstBall.GetComponent<Rigidbody2D>();
        
        this.Balls = new List<CS_ball>
        {
            firstBall
        };
            
    }
}