using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   public bool IsGameStarted { get;  set; }
}

