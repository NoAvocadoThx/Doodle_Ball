using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Damage : MonoBehaviour
{
    public ParticleSystem DeathEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallDeathTrigger.IsInvincible == true && gameObject.GetComponent<CircleCollider2D>() != null && collision.gameObject.tag == "Player")
        {

            GameObject go = Instantiate(DeathEffect.gameObject, gameObject.transform.position ,Quaternion.identity);
            go.GetComponent<ParticleSystem>().Play();
            Destroy(go, 3.0f);
            Destroy(gameObject.transform.parent.gameObject);
        }

        if (collision.gameObject.tag == "Blocker" || collision.gameObject.tag == "Boost")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (BallDeathTrigger.IsInvincible == true && gameObject.GetComponent<CircleCollider2D>() != null && collision.gameObject.tag == "Player")
        {
           
            GameObject go = Instantiate(DeathEffect.gameObject, gameObject.transform.position, Quaternion.identity);
            go.GetComponent<ParticleSystem>().Play();
            Destroy(go, 3.0f);
            Destroy(gameObject.transform.parent.gameObject);

        }
    }
   
}
