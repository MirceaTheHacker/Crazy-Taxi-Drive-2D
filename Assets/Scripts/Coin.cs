using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource m_AudioSource { get { return GetComponent<AudioSource>(); } }
    private SpriteRenderer m_Renderer { get { return GetComponent<SpriteRenderer>(); } }
    private CircleCollider2D m_CircleCollider2d { get { return GetComponent<CircleCollider2D>(); } }
    private bool used = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (used) return;
        if (other.gameObject.tag == "Player")
        {
            used = true;
            GameManager.Instance.m_CoinManager.AddCoins(1);
            StartCoroutine(OnDestroyHandler());
        }
    }

    internal IEnumerator OnDestroyHandler()
    {
        m_Renderer.enabled = false;
        m_AudioSource.Play();
        m_CircleCollider2d.enabled = false;
        while (m_AudioSource.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
