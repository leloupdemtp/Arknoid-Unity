using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ball : MonoBehaviour
{
    public static event Action<CS_ball> OnBallDelete;
    internal void Delete()
    {
        OnBallDelete?.Invoke(this);
        Destroy(gameObject, 1);
    }

 
}
