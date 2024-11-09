using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Missile : MonoBehaviour
{
    public float missileSpeed = 7;
    Vector3 velocity = Vector3.zero;
    public float missileMaxSpeed = 10;
    public float accelerationTime = 2;
    Vector3 missileDirection = new Vector3(0f, 0f);

    private float missileAcceleration;

    public Transform player;

    private void Start()
    {
        missileAcceleration = missileMaxSpeed / accelerationTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * missileSpeed;
        Destroy(gameObject, 3);
        missileMove();
    }

    void missileMove()
    {
        missileDirection = Vector3.up;
        transform.position += missileDirection * Time.deltaTime * missileSpeed;


        if (missileDirection.magnitude == 0)
        {
            velocity += -missileAcceleration * Time.deltaTime * velocity.normalized;
        }


        velocity += missileAcceleration * Time.deltaTime * missileDirection.normalized;
        transform.position += velocity * Time.deltaTime;

    }



}
