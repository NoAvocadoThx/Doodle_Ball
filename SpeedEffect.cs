using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public float FastEffectThreshhold = 1;
    public float SlowEffectThreshhold = 1;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem SlowEffect = transform.Find("SlowParticle").gameObject.GetComponent<ParticleSystem>();
        ParticleSystem FastEffect = transform.Find("FastParticle").gameObject.GetComponent<ParticleSystem>();
        SlowEffect.Stop();
        FastEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        ParticleSystem SlowEffect = transform.Find("SlowParticle").gameObject.GetComponent<ParticleSystem>();
        ParticleSystem FastEffect = transform.Find("FastParticle").gameObject.GetComponent<ParticleSystem>();

        if (BallMovement.DisableLineSpeedBoost)
        {
            SlowEffect.Play();
            FastEffect.Stop();

        }
        else
        {
            SlowEffect.Stop();
            FastEffect.Play();

        }
        Vector2 dir = BallRigidbody.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // create the particle system behind the ball
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle - 90) -180));

        //change the magnitude of effect based on speed
        float BallSpeed = BallRigidbody.velocity.sqrMagnitude;
        var mainFast = FastEffect.main;
        var mainSlow = SlowEffect.main;
        if(BallSpeed<=5)
        {
            mainFast.startSpeed = 0;
        }
        else
        {
            mainFast.startSpeed = BallSpeed * FastEffectThreshhold;
        }
        if (BallSpeed <= 0.5)
        {
            mainSlow.startSpeed = 0;
        }
        else if (BallMovement.DisableLineSpeedBoost)
        {
            mainSlow.startSpeed = BallSpeed * SlowEffectThreshhold;
        }


    }
}
