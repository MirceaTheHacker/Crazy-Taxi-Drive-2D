using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private bool inLava = false;
    private Coroutine m_LavaCoroutine = null;
    private float enteringY;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!inLava)
            {
                inLava = true;
                m_LavaCoroutine = StartCoroutine(LavaCoroutine());
                enteringY = other.gameObject.transform.position.y;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inLava)
            {
                if (other.gameObject.transform.position.y < enteringY)
                {
                    // car fully sunmerged in lava
                }
                else
                {
                    inLava = false;
                    StopCoroutine(m_LavaCoroutine);
                }

            }
        }
    }

    private IEnumerator LavaCoroutine()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(GameManager.Instance.m_CarManager.Respawn());
        inLava = false;
    }
}
