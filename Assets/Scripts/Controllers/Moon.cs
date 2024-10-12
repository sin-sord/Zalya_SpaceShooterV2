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
 //     1. rotates the object around the targets position (the planet)
 //     2. rotates the transforms z axis (Vector3(0,0,1) is just .forward)
 //     3. and uses the speed * time.deltatime
    }
}
