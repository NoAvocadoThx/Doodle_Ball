using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Large : MonoBehaviour
{
    public Transform BallTransform;
    public float EnlargeThreshhold = 1.5f;
    public float LargeTimer = 6;

    private float Timer = 0;
    private bool IsLarge = false;
    private bool Scaled = false;
    private Vector3 PrevScale;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        IsLarge = false;
        Scaled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if (IsLarge)
        {
            Timer += Time.deltaTime;
            if (!Scaled)
            {
                BallTransform.localScale = new Vector3(EnlargeThreshhold, EnlargeThreshhold, BallTransform.localScale.z);
                Scaled = true;
            }

        }

        if (Timer >= LargeTimer)
        {
            IsLarge = false;
            Timer = 0;
            BallTransform.localScale = new Vector3(1,1, BallTransform.localScale.z);

            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallTransform = collision.transform;
        if (collision.gameObject.tag == "Blocker" || collision.gameObject.tag == "Boost")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            IsLarge = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            PrevScale = BallTransform.localScale;
        }

        
    }

   
}
