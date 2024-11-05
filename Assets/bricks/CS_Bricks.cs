using System;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem; 



public class CS_Bricks : MonoBehaviour
{
    private SpriteRenderer sr;
    public int life = 1;
    public static event Action<CS_Bricks> BrickDestruction;
    public ParticleSystem DestroyEffect;
    public bool isDestroyed;
   

    private void Start()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
        this.sr.sprite = CS_BrickManager.Instance.Sprites[this.life -1];
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
            isDestroyed = true;
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

    }
}
