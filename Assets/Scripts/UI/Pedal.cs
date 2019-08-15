using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pedal : MonoBehaviour
{
    public Sprite normalPedal;
    public Sprite pressedPedal;

    private Image currentImage { get { return GetComponent<Image>(); } }
    //private Button pedal {get{return GetComponent<Button>();}}

    // private void Update()
    // {
    //     GameManager.Instance.m_CarManager.m_CarController.movement = CrossPlatformInputManager.GetAxis("Vertical");
    // }

    public void PressPedal(bool forward)
    {
        if (forward)
        {
            GameManager.Instance.m_CarManager.m_CarController.movement = 1;
        }
        else
        {
            GameManager.Instance.m_CarManager.m_CarController.movement = -1;
        }
        currentImage.sprite = pressedPedal;
    }

    public void ReleasePedal()
    {
        GameManager.Instance.m_CarManager.m_CarController.movement = 0;
        currentImage.sprite = normalPedal;
    }

}
