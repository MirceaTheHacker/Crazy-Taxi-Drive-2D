using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlagAbstract : MonoBehaviour
{
    bool used = false;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (used) return;
        if (other.tag == "Player")
        {
            used = true;
            OnTriggerEnter2DHandler(other);
        }
    }

    protected abstract void OnTriggerEnter2DHandler(Collider2D other);
}
