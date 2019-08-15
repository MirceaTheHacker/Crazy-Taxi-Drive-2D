using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroHandler : MonoBehaviour
{
    private Toggle m_Toggle { get { return GetComponent<Toggle>(); } }

    private void Start()
    {
        GameManager.Instance.m_NitroHandler = this;
    }

    internal void OnResetHandler()
    {
        m_Toggle.isOn = false;
    }

    public void NitroToggle()
    {
        GameManager.Instance.m_CarManager.m_CarController.NitroToggle();
    }
}
