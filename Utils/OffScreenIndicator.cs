using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenIndicator : MonoBehaviour
{
    public Transform Ball;
    public Transform Ceiling;

    public float yPosition = 1;
    private bool ShouldShow;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ball.position.y>Ceiling.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        transform.position = new Vector3(Ball.position.x, yPosition, transform.position.z);
    }
}
