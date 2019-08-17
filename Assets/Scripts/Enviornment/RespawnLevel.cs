using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLevel : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.m_RespawnLevel = gameObject.transform.position.y;
    }
}
