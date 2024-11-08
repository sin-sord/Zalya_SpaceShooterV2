using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShooter : MonoBehaviour
{
    public float speed;
    public float hSpeed;
    public float elapsedPrecent;
    float totalPrecent = 10;

    Vector3 pointA = new Vector3(-20, -9);
    Vector3 pointB = new Vector3(17, -9);

    public float timeToPointB;
    public float pointBTime = 5;

    public Transform enemySight;
    public Transform player;
    public SpriteRenderer enemySightRec;

    private void Start()
    {
        transform.position = pointA;
        enemySightRec.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        EnemeyMovement();
        EnemyDetection();

    }


    void EnemeyMovement()
    {
        float interpolation = elapsedPrecent / totalPrecent;

        timeToPointB += Time.deltaTime;

        if (timeToPointB < pointBTime)
        {
            transform.position = Vector3.Lerp(transform.position, pointB, interpolation * speed * Time.deltaTime);
        }
        
        else if(timeToPointB > pointBTime)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, interpolation * speed * Time.deltaTime);
            
        }

        if (timeToPointB > 10.0f)
        {
            timeToPointB = 0;
        }





       /* if (transform.position.x <= -24)
        {

            transform.position = new Vector3(transform.position.x + hSpeed * Time.deltaTime, transform.position.y);
            
        }

        else 
        {
            transform.position = new Vector3(transform.position.x - hSpeed * Time.deltaTime, transform.position.y);

        }*/

    }

    void EnemyDetection()
    {

/*        if(enemySight == player)
        {
            enemySightRec.color = new Color(1,0,0,1,0.5f);
        }
        else
        {
            enemySightRec.color = Color.green;
        }*/

    }


    void oldCode()
    {
        /*  if(Vector3.Distance(pointA, pointB) > totalPrecent)
          {
              Vector3.Lerp(pointB, pointA, interpolation * speed * Time.deltaTime);
          }

          if (Vector3.Distance(pointB, pointA) > totalPrecent)
          {
              Vector3.Lerp(pointA, pointB, interpolation * speed * Time.deltaTime);
          }*/
    }
}
