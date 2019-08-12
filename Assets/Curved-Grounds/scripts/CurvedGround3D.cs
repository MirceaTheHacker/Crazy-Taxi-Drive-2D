using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedGround3D : CurvedGround {

    [SerializeField]private float __zdepth = 5;

    public float zdepth
    {
        get { return __zdepth; }
        set { __zdepth = value; }
    }

    public override void renderCurveFromPoints(List<Vector3> points)
    {
       
       
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        Vector3 tempPoint;
        int nbPoints = points.Count;
        Vector3[] vertices = new Vector3[nbPoints * 3];
        
        for(int i = 0; i < nbPoints; i++)
        {
            vertices[i] = points[i];

            tempPoint = new Vector3();
            tempPoint.x = points[i].x;
            tempPoint.y = points[i].y;
            tempPoint.z = points[i].z + zdepth;
            vertices[nbPoints + i] = tempPoint;

            tempPoint = new Vector3();
            tempPoint.x = points[i].x;
            tempPoint.z = points[i].z;
            tempPoint.y = yheight - transform.position.y;

           

            vertices[2 * nbPoints + i] = tempPoint;

        }

        mesh.vertices = vertices;

        int[] tri = new int[2 * (nbPoints - 1) * 2 * 3];

        for(int i = 0; i<nbPoints -1; i++)
        {
            tri[2 * 3 * i] = i;
            tri[2 * 3 * i + 1] = nbPoints + i;
            tri[2 * 3 * i + 2] = i+1;
            tri[2 * 3 * i + 3] = i+1;
            tri[2 * 3 * i + 4] = nbPoints + i;
            tri[2 * 3 * i + 5] = nbPoints + i + 1 ;

            tri[(nbPoints - 1) * 2 * 3 + 2 * 3 * i] = i;
            tri[(nbPoints - 1) * 2 * 3 + 2 * 3 * i + 1] = 2 * nbPoints + i + 1;
            tri[(nbPoints - 1) * 2 * 3 + 2 * 3 * i + 2] = 2 * nbPoints + i;
            tri[(nbPoints - 1) * 2 * 3 + 2 * 3 * i + 3] = 2 * nbPoints + i + 1;
            tri[(nbPoints - 1) * 2 * 3 + 2 * 3 * i + 4] = i;
            tri[(nbPoints - 1) * 2 * 3 + 2 * 3 * i + 5] = i+1;
            

        }
        mesh.triangles = tri;

        mf.mesh = mesh;
        MeshCollider mc = GetComponent<MeshCollider>();
        mc.sharedMesh = mesh; 

    }


}
 