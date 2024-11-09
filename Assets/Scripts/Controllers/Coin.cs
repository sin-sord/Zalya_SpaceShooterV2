using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;

    bool coinCollected = false;

    void Start()
    {
        player.gameObject.CompareTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        coin();
        coinScore();

    }

    void coin()
    {



        if (Vector3.Distance(transform.position, player.transform.position) <= 1)
        {
            coinCollected = true;
            // Debug.Log("touched by player");
            Destroy(gameObject);

        }

    }

    void coinScore()
    {
        if (coinCollected == true)
        {
            print("Coin Collected");
        }

    }
}
