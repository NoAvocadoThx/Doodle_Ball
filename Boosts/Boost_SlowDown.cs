using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_SlowDown : MonoBehaviour
{
    public BallMovement BallRigidbody;
    public float SlowVelocityThreshhold = 1;
    public float SlowDownTimer = 5;
    public float SlowDownMaxSpeed = 2.5f;

    private bool IsSlowingDown = false;
    private float Timer = 0;
    private float PrevSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (IsSlowingDown)
        {
           
            BallMovement.DisableLineSpeedBoost = true;
            Timer += Time.deltaTime;
           
        }
        if(Timer >= SlowDownTimer)
        {
            IsSlowingDown = false;
            Timer = 0;
            BallMovement.DisableLineSpeedBoost = false;
            BallMovement.X_MaxSpeed = PrevSpeed;

            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blocker" || collision.gameObject.tag == "Boost")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            IsSlowingDown = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            PrevSpeed = BallMovement.X_MaxSpeed;
            BallMovement.X_MaxSpeed = SlowDownMaxSpeed;
        }

       
    }

}
