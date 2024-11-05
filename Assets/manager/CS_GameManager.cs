
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class CS_GameManager : MonoBehaviour
{
    #region Singleton

    private static CS_GameManager instance;

    public static CS_GameManager Instance => instance;

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
    public GameObject gameOverScren;
    public int ManyLives = 3;
     public static int Lives { get; set; }
    public bool IsGameStarted { get; set; }
    public TextMeshProUGUI LifeUI;
    public GameObject youWinScreen;



    public TextMeshProUGUI ScoreBoard;
    static public float score;
 

    private void Start()
    {
        Screen.SetResolution(550, 950, false);
        CS_ball.OnBallDelete += OnBallDelete;
        Lives = ManyLives;
        
    
    }
    private void Update()
    {
        LifeUI.text= "Vie:" + Lives;
        ScoreBoard.text = "Score :" + score;

        if (score ==3600)
        
        {
            youWinScreen.SetActive(true);
            IsGameStarted = false;
        }
        
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnBallDelete(CS_ball obj)
    {
        if (CS_BallManager.Instance.Balls.Count <= 0)
        {
           Lives--;

            if (Lives < 1)
            {
                gameOverScren.SetActive(true);
            }
            else
            {
                CS_BallManager.Instance.ResetBalls();
                IsGameStarted = false;

            }
        }


    }


  
}
  

