using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float InitVelocityX = 2.0f;
    public GameObject LineObj;
    public float LineSpeedDividend = 10;
    [SerializeField]static public float X_MaxSpeed = 6;
    public float Y_MaxSpeed = 6;

    public static bool DisableLineSpeedBoost = false;
    private float time;
    private bool VelocitySet;
    bool OnLine;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        VelocitySet = true;
        OnLine = false;
        DisableLineSpeedBoost = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        DrawLine LineObject = LineObj.GetComponent<DrawLine>();
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if(LineObject!= null && LineObject.Started)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
           
            if (VelocitySet)
            {
               rigidbody2D.velocity = new Vector2(InitVelocityX, 0);
               rigidbody2D.gravityScale = 0.5f;
               VelocitySet = false;
            }
            
        }
        float XMaxSpeed = 0;
        float YMaxSpeed = 0;

      

        if (OnLine)
        {
            XMaxSpeed = Mathf.Min(X_MaxSpeed, Mathf.Max(-1, rigidbody2D.velocity.x + rigidbody2D.velocity.x * time / LineSpeedDividend));
            YMaxSpeed = Mathf.Min(Y_MaxSpeed, Mathf.Max(-1, rigidbody2D.velocity.y + rigidbody2D.velocity.y * time / LineSpeedDividend));
            rigidbody2D.velocity = new Vector2(XMaxSpeed, YMaxSpeed);
            time += Time.deltaTime;
        }
        XMaxSpeed = Mathf.Min(X_MaxSpeed, rigidbody2D.velocity.x);
        YMaxSpeed = Mathf.Min(Y_MaxSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = new Vector2(XMaxSpeed, YMaxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            OnLine = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Line")
        {
           
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            OnLine = false;
            time = 0;
        }
    }

    public float GetXMaxSpeed()
    {
        return X_MaxSpeed;
    }

    public void SetXMaxSpeed(float maxSpeed)
    {
        X_MaxSpeed= maxSpeed;
    }
}
