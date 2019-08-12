using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedGround2D : CurvedGround
{

  





    public override void renderCurveFromPoints(List<Vector3> points)
    {
        

        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        int nbPoints = points.Count;
        Vector3 tempPoint;
       
        Vector3[] vertices = new Vector3[nbPoints * 2];
        
        for (int i = 0; i < nbPoints; i++)
        {
            vertices[i] = points[i];


            tempPoint = new Vector3();
            tempPoint.x = points[i].x;
            tempPoint.z = points[i].z;
            tempPoint.y = yheight - transform.position.y;



            vertices[nbPoints + i] = tempPoint;

        }

        mesh.vertices = vertices;

        int[] tri = new int[(nbPoints - 1) * 2 * 3];

        for (int i = 0; i < nbPoints - 1; i++)
        {
            tri[2 * 3 * i] = i;
            tri[2 * 3 * i + 1] = nbPoints + i + 1;
            tri[2 * 3 * i + 2] = nbPoints +i;
            tri[2 * 3 * i + 3] = i;
            tri[2 * 3 * i + 4] = i+1;
            tri[2 * 3 * i + 5] = nbPoints + i + 1;



        }
        mesh.triangles = tri;

        mf.mesh = mesh;

        

        Vector2[] points2d = new Vector2[points.Count + 2];

        points2d[0] = points[0];
        points2d[0].y = yheight - transform.position.y;

        for (int i=0; i< nbPoints; i++)
        {
            points2d[i + 1].x = points[i].x;
            points2d[i + 1].y = points[i].y;
        }

        points2d[nbPoints + 1] = points[nbPoints - 1];
        points2d[nbPoints + 1].y = yheight - transform.position.y;

       

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        edgeCollider.points = points2d;

    }

    


}
