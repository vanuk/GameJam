using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float spawnDelay;
    public bool spawnerIsActive;

    private void Start()
    {
        spawnerIsActive = true;
        StartCoroutine("SpawnMobs");
        
    }

    IEnumerator SpawnMobs()
    {
        while (spawnerIsActive)
        {
            var randInt = Random.Range(0, enemiesPrefabs.Length);
            var enemy = Instantiate(enemiesPrefabs[randInt], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
