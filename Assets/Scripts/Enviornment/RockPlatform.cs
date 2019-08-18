using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPlatform : MonoBehaviour
{
    public AnimationClip m_InstatiationClip;

    private PlatformSpawner m_PlatformSpawner;
    private Animator m_Animator { get { return GetComponent<Animator>(); } }
    private bool checkIfTouchingGround = false;
    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }
    private bool sinkCoroutineStarted = false;



    // Start is called before the first frame update
    void Start()
    {
        m_PlatformSpawner = GetComponentInParent<PlatformSpawner>();
        if (m_PlatformSpawner == null)
        {
            Debug.Log("Platform spawner is null");
        }
        StartCoroutine(DisableAnimator());
        m_Animator.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!checkIfTouchingGround) return;
        if (other.collider.tag == "Ground")
        {
            if (!sinkCoroutineStarted)
            {
                StartCoroutine(SinkRock());
            }

        }
    }


    private IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(m_InstatiationClip.length);
        yield return new WaitForSeconds(2f);
        m_Animator.enabled = false;
        yield return new WaitForSeconds(2f);
        checkIfTouchingGround = true;
    }

    private IEnumerator SinkRock()
    {
        sinkCoroutineStarted = true;
        //m_PlatformSpawner.SpawnRock();
        float startY = gameObject.transform.position.y;
        while (Mathf.Abs(startY - gameObject.transform.position.y) < 5f)
        {
            m_Rigidbody2d.mass *= 1.1f;
            yield return new WaitForSeconds(0.2f);
        }
        m_PlatformSpawner.DestroyOneRock();
    }
}
