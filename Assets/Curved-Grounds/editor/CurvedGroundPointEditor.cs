using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CurvedGroundPoint))]
public class BezierCurvedGroundPointEditor : Editor {

    CurvedGroundPoint point = null;
    private void OnEnable()
    {
        point = (CurvedGroundPoint)target;
    }

    private void OnSceneGUI()
    {
        CurvedGroundEditor.drawPointsOnSceneGui(point.curve.anchorPoints);
    }

    

}
