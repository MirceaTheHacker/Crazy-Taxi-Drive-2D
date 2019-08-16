using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour
{
    internal float webGLmovement;

    private float localMovement;

    private void Start()
    {
        GameManager.Instance.m_InputManager = this;
    }

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
        if (webGLmovement != 0) localMovement = webGLmovement;
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
