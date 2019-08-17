using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private bool inLava = false;
    private Coroutine m_LavaCoroutine = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!inLava)
            {
                inLava = true;
                m_LavaCoroutine = StartCoroutine(LavaCoroutine());
            }
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         if (inLava)
    //         {
    //             Debug.Log("OnTriggerExit called in lava");
    //             inLava = false;
    //             StopCoroutine(m_LavaCoroutine);
    //         }
    //     }
    // }

    private IEnumerator LavaCoroutine()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.m_CarManager.Respawn();
        inLava = false;
    }
}
