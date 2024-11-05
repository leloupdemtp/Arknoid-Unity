using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CS_ball : MonoBehaviour
{
    public static event Action<CS_ball> OnBallDelete;
    public static bool scored;

    internal void Delete()
    {
        OnBallDelete?.Invoke(this);
        Destroy(gameObject, 1);
    }


   
}
