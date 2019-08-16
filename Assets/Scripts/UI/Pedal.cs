using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pedal : MonoBehaviour
{
    public Sprite normalPedal;
    public Sprite pressedPedal;

    private Image currentImage { get { return GetComponent<Image>(); } }

    public void PressPedal(bool forward)
    {
        currentImage.sprite = pressedPedal;
        float localMovement;
        if (forward)
        {
            localMovement = 1;
        }
        else
        {
            localMovement = -1;
        }

        GameManager.Instance.m_InputManager.webGLmovement = localMovement;
    }

    public void ReleasePedal()
    {
        currentImage.sprite = normalPedal;
        GameManager.Instance.m_InputManager.webGLmovement = 0;
    }

}
