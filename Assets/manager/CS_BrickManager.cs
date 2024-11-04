using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CS_BrickManager : MonoBehaviour
{
    #region Singleton

    private static CS_BrickManager instance;

    public static CS_BrickManager Instance => instance;

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

    internal void LoadLevel(object currentLevel)
    {
        throw new NotImplementedException();
    }
    #endregion

  
    public Sprite[] Sprites;
   

    
  
   
}

    
