using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject CurLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2D;

    public List<Vector2> FingerPos;

    public bool Started;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        // check click
        if (Input.GetMouseButtonDown(0))
        {
            // Destroy prev line
            Destroy(CurLine);
            CreateLine();
            Started = true;
        }
        // check if we holding
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // check if the user drawed line is greater than 0.1
            if (Vector2.Distance(tempFingerPos, FingerPos[FingerPos.Count - 1]) > 0.1F)
            {
                UpdateLine(tempFingerPos);
            }
        }
    }

    void CreateLine()
    {
        CurLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = CurLine.GetComponent<LineRenderer>();
        edgeCollider2D = CurLine.GetComponent<EdgeCollider2D>();
        FingerPos.Clear();
        // first finger input
        FingerPos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        // second finger input
        FingerPos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, FingerPos[0]);
        lineRenderer.SetPosition(1, FingerPos[1]);
        // set edge collider points 
        edgeCollider2D.points = FingerPos.ToArray();
        CurLine.gameObject.tag = "Line";
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        FingerPos.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        // set edge collider points 
        edgeCollider2D.points = FingerPos.ToArray();
    }
}
