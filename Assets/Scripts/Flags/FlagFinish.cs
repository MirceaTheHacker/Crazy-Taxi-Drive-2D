using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagFinish : FlagAbstract
{
    protected override void OnTriggerEnter2DHandler(Collider2D other)
    {
        GameManager.Instance.GameWinHandler();
    }
}
