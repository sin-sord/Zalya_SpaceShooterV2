using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    Coroutine coinSpawner;


    private void Start()
    {
        coinSpawner = StartCoroutine(SpawnCoin());

    }

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Vector3 spawnCoin = new Vector3(Random.Range(-20, 20), Random.Range(0, 5), 0);
            Instantiate(coinPrefab, spawnCoin, transform.rotation);

        }


    }
}
