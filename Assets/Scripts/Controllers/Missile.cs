using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float missileSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * missileSpeed;
        Destroy(gameObject, 3); 
    }

}
