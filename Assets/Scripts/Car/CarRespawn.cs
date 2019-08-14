using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawn : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }
    private CarManager m_CarManager { get { return GetComponentInParent<CarManager>(); } }

    internal void Respawn(Vector2 checkpoint)
    {
        gameObject.transform.position = checkpoint;
        gameObject.transform.rotation = Quaternion.identity;
        m_Rigidbody2d.velocity = Vector3.zero;
        m_Rigidbody2d.angularVelocity = 0;
        GameManager.Instance.m_HealthManager.UpdateHearts(1);
        m_CarManager.m_CarController.m_Fuel = 1;
    }
}
