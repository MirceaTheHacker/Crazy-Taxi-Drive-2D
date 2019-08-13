using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    internal Image m_Image { get { return GetComponent<Image>(); } }

    private void Start()
    {
        GameManager.Instance.m_FuelManager = this;
    }
}
