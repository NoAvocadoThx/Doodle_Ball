using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingScaler : MonoBehaviour
{

    public float yOffset = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraRightMiddle = Camera.main.ViewportToWorldPoint(new Vector2(1, yOffset));
        cameraRightMiddle.x = transform.position.x;

        transform.position = new Vector3(cameraRightMiddle.x, cameraRightMiddle.y, 2);
    }
}
