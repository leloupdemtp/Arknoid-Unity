
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    public int Lives { get; set; }
    public bool IsGameStarted { get; set; }
    public TextMeshProUGUI LifeUI;

    public TextMeshProUGUI ScoreBoard;
     public float score;


    private void Start()
    {
        Screen.SetResolution(550, 950, false);
        CS_ball.OnBallDelete += OnBallDelete;
        Lives = ManyLives;
    
    }
    private void Update()
    {
        LifeUI.text= "Vie:" + Lives;
        if (CS_Bricks.isDestroyed == true)
        {
            score += 100;
             

        }
        ScoreBoard.text = "Score :" + score;
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnBallDelete(CS_ball obj)
    {
        if (CS_BallManager.Instance.Balls.Count <= 0)
        {
            this.Lives--;

            if (this.Lives < 1)
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
  

