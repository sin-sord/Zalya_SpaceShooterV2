using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(4, direction, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        transform.RotateAround(target.position, Vector3.forward, speed * Time.deltaTime);
    }
}
