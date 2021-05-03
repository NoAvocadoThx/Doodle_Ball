using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform BallTransform;
    public Vector3 offset;

    private float PrevXPos;
    private float CurXPos;
    // Start is called before the first frame update
    void Start()
    {
        PrevXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        PrevXPos = transform.position.x;
        transform.position = new Vector3(BallTransform.position.x + offset.x, offset.y, offset.z);
        CurXPos = transform.position.x;
        if(CurXPos<PrevXPos)
        {
            CurXPos = PrevXPos;
            transform.position = new Vector3(CurXPos,transform.position.y,transform.position.z);
        }
    }
}
