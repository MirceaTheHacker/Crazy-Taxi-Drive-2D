using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CurvedGround), true)]
public class CurvedGroundEditor : Editor {

    CurvedGround curve;
    private int selectedType;
    private string[] types = new string[] { "Bezier", "Lagrange" };

    private void OnEnable()
    {
        curve = (CurvedGround) target;
        selectedType = curve.type == CurvedGround.curveType.Bezier ? 0 : 1;
        
    }

    public override void OnInspectorGUI()
    {
        bool render = false;
        
        int selection = EditorGUILayout.Popup("type", selectedType, types);

        if (selection != selectedType)
        {
            selectedType = selection;
            render = true;

            if(selectedType == 0)
            {
                curve.type = CurvedGround.curveType.Bezier;
            }
            else
            {
                curve.type = CurvedGround.curveType.Lagrange;
            }

        }

        curve.precision = 1 / EditorGUILayout.FloatField("precision", 1 / curve.precision);
        curve.yheight = EditorGUILayout.FloatField("y-height", curve.yheight);
       

        if (curve.GetType() == typeof(CurvedGround3D))
        {
            CurvedGround3D c = (CurvedGround3D)curve;
            c.zdepth = EditorGUILayout.FloatField("z-depth", c.zdepth);
        }
        CurvedGroundPoint toDelete = null;
        foreach (CurvedGroundPoint point in curve.anchorPoints)
        {
            if (drawPointInInspector(point))
                toDelete = point;
        }

        if(toDelete != null)
        {
            curve.anchorPoints.Remove(toDelete);
            DestroyImmediate(toDelete.gameObject);
        }

        

        if (GUILayout.Button("add point"))
        {
            Vector3 point = new Vector3(0, 0, 0);
            if(curve.anchorPoints.Count > 0)
            { 
                Vector3 lastPoint = curve.anchorPoints[curve.anchorPoints.Count - 1].position;
                point.x = lastPoint.x + 5;
                point.y = lastPoint.y;
                point.z = 0;
            }
            curve.addPointAtPosition(point);

        }

        if (GUILayout.Button("update"))
            render = true;


        if (render)
            curve.renderCurveMesh();
        

    }

    private void OnSceneGUI()
    {
        Handles.color = Color.green;
        CurvedGroundEditor.drawPointsOnSceneGui(curve.anchorPoints);
    }
    bool drawPointInInspector(CurvedGroundPoint point)
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("X", GUILayout.Width(20)))
            return true;
        

        EditorGUILayout.ObjectField(point.gameObject, typeof(GameObject), true);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        return false;


    }

    public static void drawPointsOnSceneGui(List<CurvedGroundPoint> points)
    {
        foreach (CurvedGroundPoint point in points)
        {
            Handles.color = Color.green;
            Vector3 newPosition = Handles.FreeMoveHandle(point.position, point.transform.rotation, HandleUtility.GetHandleSize(point.position) * 0.2f, Vector3.zero, Handles.CubeHandleCap);
            if (point.position != newPosition)
                point.position = newPosition;
        }
    }



    

}

