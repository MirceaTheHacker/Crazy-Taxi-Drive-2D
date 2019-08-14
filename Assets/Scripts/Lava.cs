using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private bool inLava = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!inLava)
            {
                inLava = true;
                StartCoroutine(LavaCoroutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inLava)
            {
                Debug.Log("OnTriggerExit called in lava");
                inLava = false;
                StopCoroutine(LavaCoroutine());
            }
        }
    }

    private IEnumerator LavaCoroutine()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.m_CarManager.Respawn();
    }
}
