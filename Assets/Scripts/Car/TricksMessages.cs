using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricksMessages : MonoBehaviour
{
    private Rigidbody2D m_CarBody { get { return GetComponentInChildren<Rigidbody2D>(); } }
    float currentAngle;
    Coroutine m_FlippingCoroutine = null;
    bool inCoroutine = false;

    // Start is called before the first frame update
    void Start()
    {

    }

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
        while (!flipped)
        {
            if (Mathf.Abs(currentAngle) == 0) break;
            if (Mathf.Abs(currentAngle) < 0.5f)
            {
                StartCoroutine(GameManager.Instance.m_UIManager.DisplayFlip());
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        inCoroutine = false;
    }
}
