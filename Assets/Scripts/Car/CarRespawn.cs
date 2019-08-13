using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawn : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }

    internal void Respawn(Vector2 checkpoint)
    {
        gameObject.transform.position = checkpoint;
        gameObject.transform.rotation = Quaternion.identity;
        m_Rigidbody2d.velocity = Vector3.zero;
        m_Rigidbody2d.angularVelocity = 0;
    }
}
