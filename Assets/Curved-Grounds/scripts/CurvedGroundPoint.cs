using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedGroundPoint : MonoBehaviour {
    [SerializeField] private CurvedGround __curve;
    public CurvedGround curve
    {
        get { return __curve; }
        set { __curve = value; }
    }
    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
}
