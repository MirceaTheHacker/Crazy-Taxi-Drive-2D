using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    internal CarController m_CarController { get { return GetComponentInChildren<CarController>(); } }

    private void Start()
    {
        GameManager.Instance.m_CarManager = this;
    }

}
