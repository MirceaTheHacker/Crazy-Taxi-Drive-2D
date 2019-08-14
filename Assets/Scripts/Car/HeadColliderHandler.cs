using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColliderHandler : MonoBehaviour
{
    internal Vector2 m_CheckPoint;
    private CarRespawn m_CarClass;

    private void Start()
    {
        m_CarClass = GetComponentInParent<CarRespawn>();
        m_CheckPoint = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            m_CarClass.Respawn(m_CheckPoint);
        }
    }
}
