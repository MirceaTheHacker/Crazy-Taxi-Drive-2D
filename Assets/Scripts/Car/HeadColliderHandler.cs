using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColliderHandler : MonoBehaviour
{

    private CarManager m_CarManager { get { return GetComponentInParent<CarManager>(); } }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            m_CarManager.Respawn();
        }
    }
}
