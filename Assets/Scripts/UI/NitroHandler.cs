using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NitroHandler : MonoBehaviour
{
    internal Toggle m_Toggle { get { return GetComponent<Toggle>(); } }

    private TextMeshProUGUI text { get { return GetComponentInChildren<TextMeshProUGUI>(); } }
    private Color enabledColor = new Color32(255, 0, 0, 255);
    private Color disabledColor = new Color32(255, 255, 255, 50);


    private void Start()
    {
        GameManager.Instance.m_NitroHandler = this;

        m_Toggle.isOn = false;
        SetDisabledStyle();
    }

    public void NitroToggle()
    {
        if (m_Toggle.isOn)
        {
            SetEnabledStyle();
            GameManager.Instance.m_CarManager.m_CarController.TurnNitroOn();
        }
        else
        {
            SetDisabledStyle();
            GameManager.Instance.m_CarManager.m_CarController.TurnNitroOff();
        }
    }

    private void SetEnabledStyle()
    {
        text.color = enabledColor;
    }

    private void SetDisabledStyle()
    {
        text.color = disabledColor;
    }
}
