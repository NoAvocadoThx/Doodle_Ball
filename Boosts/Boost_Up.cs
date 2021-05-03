using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Up : MonoBehaviour
{
    public float UpVelocityThreshhold = 1;
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

        if (collision.gameObject.tag == "Blocker" || collision.gameObject.tag == "Boost")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            float YMaxSpeed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y + UpVelocityThreshhold;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, YMaxSpeed);
            gameObject.SetActive(false);
        }

       
    }



}
