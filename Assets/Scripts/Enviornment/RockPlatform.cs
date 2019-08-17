using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPlatform : MonoBehaviour
{
    public AnimationClip m_InstatiationClip;
    public GameObject m_SpawnState;

    private Animator m_Animator { get { return GetComponent<Animator>(); } }
    private bool checkIfTouchingGround = false;
    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }
    private Vector3 spawnLocation;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableAnimator());
        spawnLocation = gameObject.transform.position;
        Debug.Log("Initial location  = " + spawnLocation);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!checkIfTouchingGround) return;
        if (other.collider.tag == "Ground")
        {
            StartCoroutine(SinkRock());
        }
    }


    private IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(m_InstatiationClip.length);
        m_Animator.enabled = false;
        yield return new WaitForSeconds(2f);
        checkIfTouchingGround = true;
    }

    private IEnumerator SinkRock()
    {
        Debug.Log("Current location = " + gameObject.transform.position);
        Instantiate(m_SpawnState, spawnLocation, Quaternion.identity);
        float startY = gameObject.transform.position.y;
        while (Mathf.Abs(startY - gameObject.transform.position.y) < 5f)
        {
            m_Rigidbody2d.mass *= 1.1f;
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(gameObject);
    }
}
