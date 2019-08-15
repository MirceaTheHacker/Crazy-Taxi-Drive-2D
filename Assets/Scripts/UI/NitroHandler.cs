using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroHandler : MonoBehaviour
{


    public void NitroToggle()
    {
        GameManager.Instance.m_CarManager.m_CarController.NitroToggle();
    }
}
