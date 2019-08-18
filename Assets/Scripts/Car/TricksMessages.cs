using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricksMessages : MonoBehaviour
{
    private Rigidbody2D m_CarBody { get { return GetComponentInChildren<Rigidbody2D>(); } }
    private CarManager m_CarManager { get { return GetComponentInChildren<CarManager>(); } }
    float currentAngle;
    Coroutine m_FlippingCoroutine = null;
    bool inCoroutine = false;


    // Update is called once per frame
    void Update()
    {
        currentAngle = m_CarBody.transform.rotation.z;
        if (inCoroutine) return;
        if (Mathf.Abs(currentAngle) > 0.95 || Mathf.Abs(currentAngle) < -0.95)
        {
            m_FlippingCoroutine = StartCoroutine(FlippingCoroutine());
        }

    }

    private IEnumerator FlippingCoroutine()
    {
        inCoroutine = true;
        bool flipped = false;
        float startX = gameObject.transform.position.x;
        while (!flipped)
        {
            if (Mathf.Abs(currentAngle) == 0) break;
            if (Mathf.Abs(currentAngle) < 0.5f)
            {
                if (Mathf.Approximately(m_CarManager.m_CheckPoint.x, startX))
                {
                    Debug.Log("Not displaying great flip message because you died :-(");
                }
                else
                {
                    StartCoroutine(GameManager.Instance.m_UIManager.DisplayFlip());
                }
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        inCoroutine = false;
    }
}
