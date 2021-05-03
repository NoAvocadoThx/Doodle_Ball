using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Ball;
    public Text ScoreText;

    private float StartPos, dist, prevDist;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = Ball.position.x;
        dist = 0;
        prevDist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Mathf.Max(0,Ball.position.x - StartPos);
        if (dist > prevDist)
        {
            prevDist = dist;
        }
        ScoreText.text = (prevDist/10).ToString("F2") + "m";
    }
}
