using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDeathTrigger : MonoBehaviour
{
    public ParticleSystem DeathEffect;
    public ParticleSystem GlowEffect;
    public SpriteRenderer Ball;
    public SpriteRenderer XIcon;
    public static bool IsInvincible = false;

    private bool IsDead = false;
    private bool Played = false;
   
    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
        Played = false;
        IsInvincible = false;
        if (GlowEffect.isPlaying)
        {
            GlowEffect.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(IsDead)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (GlowEffect.isPlaying)
            {
                GlowEffect.Stop();
            }
        }
        if (!DeathEffect.isPlaying && IsDead)
        {
            SceneManager.LoadScene("MainGame");
        }
        if(IsInvincible && !GlowEffect.isPlaying)
        {
            GlowEffect.Play();
            Played = true;
        }
        else if(!IsInvincible)
        {
            GlowEffect.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Ball.enabled = false;
            XIcon.enabled = false;
            DeathEffect.Play();
            IsDead = true;
            
        }
        if (IsInvincible) return;
        if (collision.gameObject.tag == "Saw")
        {
            Ball.enabled = false;
            XIcon.enabled = false;
            DeathEffect.Play();
            IsDead = true;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Ball.enabled = false;
            XIcon.enabled = false;
            DeathEffect.Play();
            IsDead = true;

        }

        if (IsInvincible) return;
        if (collision.gameObject.tag == "Saw")
        {
            Ball.enabled = false;
            XIcon.enabled = false;
            DeathEffect.Play();
            IsDead = true;

        }
    }
   

}
