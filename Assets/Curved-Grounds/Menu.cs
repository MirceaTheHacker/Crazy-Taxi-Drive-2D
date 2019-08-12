using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Menu  {

    [MenuItem("GameObject/2D Object/2D Curved Ground")]
    static void create2DGround()
    {
        GameObject ground = new GameObject("2DCurvedGround");
        CurvedGround2D curve = ground.AddComponent<CurvedGround2D>();
        ground.AddComponent<MeshFilter>();
        ground.AddComponent<MeshRenderer>();
        ground.AddComponent<EdgeCollider2D>();
        

        curve.addPointAtPosition(new Vector3(1, 30, 0));
        curve.addPointAtPosition(new Vector3(10, 40, 0));
        curve.addPointAtPosition(new Vector3(20, 30, 0));

        setDefaulMaterial(ground);

        curve.renderCurveMesh();

        Undo.RegisterCreatedObjectUndo(ground, "created 2DCurvedGround");

    }

    [MenuItem("GameObject/3D Object/3D Curved Ground")]
    static void create3DGround()
    {
        
        GameObject ground = new GameObject("3DCurvedGround");
        CurvedGround3D curve = ground.AddComponent<CurvedGround3D>();
        ground.AddComponent<MeshFilter>();
        ground.AddComponent<MeshRenderer>();
        ground.AddComponent<MeshCollider>();

        curve.addPointAtPosition(new Vector3(1, 30, 0));
        curve.addPointAtPosition(new Vector3(10, 40, 0));
        curve.addPointAtPosition(new Vector3(20, 30, 0));


        setDefaulMaterial(ground);

        curve.renderCurveMesh();

        Undo.RegisterCreatedObjectUndo(ground, "created 3DCurvedGround");
    }

    [MenuItem("Screenshot/Take screenshot")]
    static void Screenshot()
    {
        ScreenCapture.CaptureScreenshot("tst.png");
    }

    private static void setDefaulMaterial(GameObject gameObject)
    {

        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(0, 0, 0);
        gameObject.GetComponent<Renderer>().material = mat;

    }

}
