using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollectable : MonoBehaviour
{
    public float m_FloatingVellocity;
    public float m_FloatingFrequency = 2f;
    public float m_EulerAngleAngleVelocity = 10;
    public float m_SpawnDistanceFromGround = 1f;
    public AudioSource m_CollectibleAudioSource;

    private Rigidbody2D m_Rigidody2D;
    private Transform m_InitialPosition;
    private SpriteRenderer m_Renderer { get { return GetComponent<SpriteRenderer>(); } }
    private BoxCollider2D m_BoxCollider2d { get { return GetComponent<BoxCollider2D>(); } }

    private void Awake()
    {
        m_Rigidody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveUpAndDown());
        m_InitialPosition = gameObject.GetComponent<Transform>();
        StartCoroutine(AdjustPosition());
    }

    private void FixedUpdate()
    {
        m_Rigidody2D.AddTorque(m_EulerAngleAngleVelocity * Time.deltaTime, ForceMode2D.Impulse);
    }

    private IEnumerator MoveUpAndDown()
    {
        while (true)
        {
            float startTime = Time.time;
            while (Time.time - startTime < m_FloatingFrequency)
            {
                m_Rigidody2D.AddForce(Vector2.down * m_FloatingVellocity * Time.deltaTime, ForceMode2D.Force);
                yield return new WaitForFixedUpdate();
            }
            startTime = Time.time;
            while (Time.time - startTime < m_FloatingFrequency)
            {
                m_Rigidody2D.AddForce(Vector2.up * m_FloatingVellocity * Time.deltaTime, ForceMode2D.Force);
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private IEnumerator AdjustPosition()
    {
        RaycastHit2D hit = Raycast();
        if (hit.collider != null)
        {
            while (hit.distance.Equals(0f))
            {
                m_Rigidody2D.MovePosition(new Vector2(m_Rigidody2D.transform.position.x, m_Rigidody2D.transform.position.y + m_SpawnDistanceFromGround));
                hit = Raycast();
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();
            m_Rigidody2D.MovePosition(new Vector2(m_Rigidody2D.transform.position.x, m_Rigidody2D.transform.position.y + (m_SpawnDistanceFromGround - hit.distance)));
            hit = Raycast();
            yield return new WaitForFixedUpdate();
        }
    }

    private RaycastHit2D Raycast()
    {
        return Physics2D.Raycast(gameObject.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground", "Lava"));
    }

    internal IEnumerator OnDestroyHandler()
    {
        GameManager.Instance.m_CarManager.m_CarController.m_Fuel = 1;
        m_Renderer.enabled = false;
        m_CollectibleAudioSource.Play();
        m_BoxCollider2d.enabled = false;
        while (m_CollectibleAudioSource.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wheel")
        {
            StartCoroutine(OnDestroyHandler());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player" || other.collider.tag == "Wheel")
        {
            StartCoroutine(OnDestroyHandler());

        }
    }

}
