using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryScript : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParents;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;

    Vector2 pos;

    Transform[] dotsList;

    float timeStamp;

    private void Start()
    {
        //Hide();
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];

        for(int x = 0; x < dotsNumber; x++)
        {
            dotsList[x] = Instantiate(dotPrefab, null).transform;
            dotsList[x].parent = dotsParents.transform;
        }
    }

    public void Show()
    {
        dotsParents.SetActive(true);
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for(int x = 0; x < dotsNumber; x++)
        { 
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 9f;
            // Debug.Log(Physics2D.gravity.magnitude * timeStamp * timeStamp);
            dotsList[x].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void Hide()
    {
        dotsParents.SetActive(false);
    }
    //public LineRenderer line;
    //public int resolution;

    //public Vector2 velocity;
    //public float yLimit;
    //public float g;

    //public int lineCastResolution;
    //public LayerMask canHit;

    //private IEnumerator RenderArc()
    //{
    //    line.positionCount = resolution + 1;
    //    line.SetPositions(CalculateLineArray());
    //    yield return null;
    //}
    //private Vector3[] CalculateLineArray()
    //{
    //    Vector3[] lineArray = new Vector3[resolution + 1];

    //    float lowestTimeValue = MaxTimeY() / resolution;

    //    for(int x = 0; x < lineArray.Length; x++)
    //    {
    //        float t = x / (float)lineArray.Length;
    //        lineArray[x] = CalculateLinePoint(t);
    //    }

    //    return lineArray;
    //}

    //private Vector3 CalculateLinePoint(float t)
    //{
    //    float x = velocity.x * t;
    //    float y = velocity.y * t - (g * Mathf.Pow(t, 2) / 2);
    //    return new Vector3(x + transform.position.x, y + transform.position.y);
    //}

    //private float MaxTimeY()
    //{
    //    float v = velocity.y;
    //    float vv = v * v;

    //    float t = (v + Mathf.Sqrt(vv + 2 * g * (transform.position.y - yLimit))) / g;
    //    return t;
    //}

    //private Vector2 HitPosition()
    //{
    //    float lowestTimeValue = MaxTimeY() / lineCastResolution;

    //    for (int x = 0; x < lineCastResolution; x++)
    //    {
    //        float t = lowestTimeValue * x;
    //        float tt = lowestTimeValue * (x + 1);

    //        RaycastHit2D hit = Physics2D.Linecast(CalculateLinePoint(t), CalculateLinePoint(tt), canHit);

    //        if (hit)
    //        {
    //            return hit.point;
    //        }
    //    }
    //    return CalculateLinePoint(MaxTimeY());
    //}
    //private float MaxTimeX()
    //{
    //    float x = velocity.x;
    //    float t = (HitPosition().x - transform.position.x) / x;
    //    return t;
    //}



    //// Start is called before the first frame update
    //Vector2 Direction;

    //public float force;

    //public GameObject PointPrefab;

    //public GameObject[] points;

    //public int numOfPoints;
    //void Start()
    //{
    //    points = new GameObject[numOfPoints];

    //    for(int x = 0; x < numOfPoints; x++)
    //    {
    //        points[x] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector2 gunPos = transform.position;

    //    Direction = mousePos - gunPos;

    //    faceMouse();

    //    for(int x = 0; x < points.Length; x++)
    //    {
    //        points[x].transform.position = PointPosition(x * 0.1f);
    //    }
    //}

    //void faceMouse()
    //{
    //    transform.right = Direction;
    //}

    //Vector2 PointPosition(float t)
    //{
    //    Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);

    //    return currentPointPos;
    //}
}
