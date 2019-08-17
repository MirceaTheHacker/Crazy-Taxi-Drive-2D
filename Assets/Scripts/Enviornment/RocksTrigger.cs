using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksTrigger : MonoBehaviour
{
    public GameObject[] rocks;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivateRocks();
        }
    }

    private void ActivateRocks()
    {
        foreach (GameObject rock in rocks)
        {
            rock.SetActive(true);
        }
    }
}
