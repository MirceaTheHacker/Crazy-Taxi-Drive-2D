using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCheckpoint : FlagAbstract
{
    public Sprite greenFlag;
    public Sprite redFlag;

    private SpriteRenderer m_Renderer { get { return GetComponent<SpriteRenderer>(); } }
    private AudioSource m_AudioSource { get { return GetComponent<AudioSource>(); } }

    private void Start()
    {
        m_Renderer.sprite = redFlag;
    }

    protected override void OnTriggerEnter2DHandler(Collider2D other)
    {
        m_AudioSource.Play();
        m_Renderer.sprite = greenFlag;
        CarManager carManager =
        other.gameObject.GetComponentInParent<CarManager>();
        carManager.m_CheckPoint = gameObject.transform.position;
        carManager.m_CarController.AddFuel(0.5f);
    }
}
