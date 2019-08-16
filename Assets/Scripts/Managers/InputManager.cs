using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour
{
    private float localMovement;
    void Update()
    {
        GetMovement();
        GetNitro();
    }

    private void GetMovement()
    {
        localMovement = Input.GetAxisRaw("Horizontal");
        if (localMovement == 0)
        {
            localMovement = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        }
        GameManager.Instance.m_CarManager.m_CarController.movement = localMovement;
    }

    private void GetNitro()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.Instance.m_NitroHandler.m_Toggle.isOn = !GameManager.Instance.m_NitroHandler.m_Toggle.isOn;
        }
    }
}
