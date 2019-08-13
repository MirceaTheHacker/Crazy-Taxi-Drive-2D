using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColliderHandler : MonoBehaviour
{
    private Vector2 m_CheckPoint;
    private CarController m_CarClass;

    private void Start()
    {
        m_CheckPoint = gameObject.transform.position;
        m_CarClass = GetComponentInParent<CarController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Dead");
            m_CarClass.Respawn(m_CheckPoint);
        }
    }
}
