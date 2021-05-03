using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Invincible : MonoBehaviour
{

    public float EnlargeThreshhold = 1.5f;
    public float BoostTimer = 6;

    private bool IsBoosted = false;
    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        IsBoosted = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if (IsBoosted)
        {
            Timer += Time.deltaTime;

        }

        if (Timer >= BoostTimer)
        {
            IsBoosted = false;
            BallDeathTrigger.IsInvincible = false;
            Timer = 0;
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
            IsBoosted = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            BallDeathTrigger.IsInvincible = true;
        }


    }

}
