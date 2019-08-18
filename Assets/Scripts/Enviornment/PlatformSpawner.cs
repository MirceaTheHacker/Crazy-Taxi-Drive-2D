using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject m_RockPlatformPrefab;

    private Vector3 spawnLocation;
    private List<GameObject> spawnedRocks;

    private void Awake()
    {
        spawnedRocks = new List<GameObject>();
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());

    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnRock();
            yield return new WaitForSeconds(10f);
        }

    }

    internal void SpawnRock()
    {
        GameObject newRock = Instantiate(m_RockPlatformPrefab, gameObject.transform.localPosition, m_RockPlatformPrefab.transform.rotation);
        newRock.transform.parent = gameObject.transform;
        spawnedRocks.Add(newRock);
    }

    internal void DestroyOneRock()
    {
        Destroy(spawnedRocks[0]);
        spawnedRocks.RemoveAt(0);
    }

}
