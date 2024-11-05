using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using Random = UnityEngine.Random;




public class CS_Bricks : MonoBehaviour
{
    private SpriteRenderer sr;
    public int life = 1;
    public static event Action<CS_Bricks> BrickDestruction;
    public ParticleSystem DestroyEffect;
    public static bool isDestroyed = false;
    public int Chances;
    public int Reward;
    public GameObject Multiball;
    public GameObject Enlarge;
    public GameObject Decrease;
    public GameObject OneUp;

    private void Start()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
        this.sr.sprite = CS_BrickManager.Instance.Sprites[this.life -1];
        Chances = Random.Range(1,5) ;
        
    }

    private void Update()
    {
        Reward = Random.Range(1,4);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CS_ball ball = collision.gameObject.GetComponent<CS_ball>(); //recupération de la balle
        doneCollision(ball);
       
    }

    public void doneCollision(CS_ball ball)
    {
        this.life--;
        if (this.life <= 0)
        {
            
            BrickDestruction?.Invoke(this);
            Destroy(this.gameObject);
            InstantiateEffect();
            CS_GameManager.score += 100;
           
        }
        else
        {
            this.sr.sprite = CS_BrickManager.Instance.Sprites[this.life - 1];
        }
    }

    private void InstantiateEffect()
    {
        // Effet de particule
        Vector3 brickPos = transform.position;
        GameObject effect = Instantiate(DestroyEffect.gameObject, brickPos, Quaternion.identity);

        ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
        var mainModule = particleSystem.main;
        mainModule.startColor = sr.color;  //couleur

        Destroy(effect, DestroyEffect.main.startLifetime.constant);
        
        if (Chances == 1) 
        {
            if (Reward == 1)
            {
                Instantiate(Multiball, this.gameObject.transform.position, Quaternion.identity);
            }
            else if (Reward == 2)
            {
                Instantiate(Enlarge, this.gameObject.transform.position, Quaternion.identity);
            }
            else if (Reward == 3)
            {
                Instantiate(Decrease, this.gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(OneUp, this.gameObject.transform.position, Quaternion.identity);
            }
        }
        
        
        

    }

    
}
