using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Sprite greenFlag;
    public Sprite redFlag;

    private SpriteRenderer m_Renderer { get { return GetComponent<SpriteRenderer>(); } }

    private void Start()
    {
        m_Renderer.sprite = redFlag;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_Renderer.sprite = greenFlag;
            HeadColliderHandler headColliderHandler =
            other.gameObject.GetComponentInChildren<HeadColliderHandler>();
            headColliderHandler.m_CheckPoint = gameObject.transform.position;
        }
    }
}
