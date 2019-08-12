using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CurvedGround : MonoBehaviour {

    public enum curveType
    {
        Lagrange,
        Bezier
    }

    [SerializeField]private List<CurvedGroundPoint> __anchorPoints = new List<CurvedGroundPoint>();
    public List<CurvedGroundPoint> anchorPoints {
        get {
            return __anchorPoints;
        }
        set {
            __anchorPoints = value;
        }
    }
    [SerializeField]private float __precision = 1;
    public float precision
    {
        get {
            return __precision;
        }
        set { if(value > 0)
            {
                __precision = value;
            }
        }
    }

    [SerializeField] private curveType __type = curveType.Bezier;
    public curveType type
    {
        get { return __type;}
        set { __type = value;}
    }

    [SerializeField] private int index = 0;

    [SerializeField]private float __yheight = 0;
    public float yheight
    {
        get { return __yheight; }
        set { __yheight = value; }
    }

    public Vector3 getBezierPointAtDistance(float distance)
    {
        float t = distance / getTotalLength();
        return getBezierPointAtPercentage(t);
    }

    public Vector3 getBezierPointAtPercentage(float t)
    {
        Vector3 position = new Vector3(0, 0, 0);
        int pointsSizeMinus1 = anchorPoints.Count - 1;
        for (int i = 0; i <= pointsSizeMinus1; i++)
        {
            position = position + anchorPoints[i].position * getBezierFactorAtIndex(t, pointsSizeMinus1, i);
        }
        return position;
    }

    

    public float getTotalLength()
    {
        return anchorPoints.Count == 0 ? 0 :Mathf.Sqrt(Mathf.Pow(anchorPoints[0].position.x - anchorPoints[anchorPoints.Count - 1].position.x, 2));
    }


    private float getBezierFactorAtIndex(float t, int n, int i)
    {
        return Mathf.Pow(t, i) * Mathf.Pow((1 - t), n - i) * MathFunctions.CNKCombination(n, i);
    }


    public List<Vector3> getBezierCurvePoints()
    {
        int pointsSize = anchorPoints.Count;
        if (pointsSize <= 1)
            return new List<Vector3>();
        Vector3 lastPoint = anchorPoints[pointsSize - 1].position;

        List<Vector3> curvePoints = new List<Vector3>();

        float totalDistance = getTotalLength();
        float cumulatedDistance = 0;

        while (cumulatedDistance < totalDistance)
        {
            curvePoints.Add(getBezierPointAtDistance(cumulatedDistance));
            cumulatedDistance += precision;

        }
        curvePoints.Add(lastPoint);
        return curvePoints;

    }

    

    public void addPointAtPosition(Vector3 position)
    {

        GameObject gameObject = new GameObject("point " + index.ToString());
        CurvedGroundPoint point = gameObject.AddComponent<CurvedGroundPoint>();
        point.transform.parent = transform;
        point.position =  position;
        point.curve = this;
        anchorPoints.Add(point);
        index++;
    }
    public List<Vector3> getLangrangePoints()
    {
        List<Vector3> lagrangePoints = new List<Vector3>();
        float cumulatedDistance = 0;
        float totalDistance = getTotalLength();
        Vector3 point;
        if (anchorPoints.Count > 0)
        {
            while (cumulatedDistance < totalDistance) 
            {
                point = Vector3.zero;
                point.x = anchorPoints[0].position.x + cumulatedDistance;
                point.y = getLagrangianYValueAtXValue(point.x);
                lagrangePoints.Add(point);
                cumulatedDistance += precision;
            }
            Vector3 lastPoint = anchorPoints[anchorPoints.Count - 1].position;
            lagrangePoints.Add(lastPoint);
            return lagrangePoints;
        }

        return null;
    }

    public float getLagrangianYValueAtXValue(float x)
    {
        float sum = 0;
        int pointsCount = anchorPoints.Count;
        for (int i = 0; i < pointsCount; i++)
        {
            sum += getLagrangianValue(i, x);
        }

        return sum;
    }

    public float getLagrangianValue(int index, float x)
    {
        Vector3 currentPoint = anchorPoints[index].transform.position;
        float product = currentPoint.y;
        int pointCount = anchorPoints.Count;
        for (int i = 0; i < pointCount; i++)
        {
            if (i != index)
            {
                product *= (x - anchorPoints[i].transform.position.x) / (currentPoint.x - anchorPoints[i].transform.position.x);
            }
        }

        return product;
    }

    

    public void renderCurveMesh()
    {
        List<Vector3> points = null;
        if (type == curveType.Bezier)
        {
            points = getBezierCurvePoints();
        }
        else if (type == curveType.Lagrange)
        {
            points = getLangrangePoints();
        }

        int nbPoints = points.Count;
        Vector3 tempPoint;
        for (int i = 0; i < nbPoints; i++)
        {
            tempPoint = points[i] - transform.position;
            tempPoint.z = 0;
            points[i] = tempPoint;
        }

        renderCurveFromPoints(points);
    }

    abstract public void renderCurveFromPoints(List<Vector3> points);

}
