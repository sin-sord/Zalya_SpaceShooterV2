using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShooter : MonoBehaviour
{
   // public float speed;
    public float horizontalSpeed;
  //  public float elapsedPrecent;
  //  float totalPrecent = 10;

    Vector3 startingPosition = new Vector3(-22, -9);
   // Vector3 pointB = new Vector3(17, -9);

    public float timeToOtherSide;
    //  public float pointBTime = 3;

    public Transform enemySight;
    //public Transform player;
    public SpriteRenderer enemySightRec;

    public GameObject playerOBJ;
    Color sightColor;

    public Transform missileSpawn;
    public GameObject missilePrefab;
    public float missileDelay = 0.03f;

    private void Start()
    {
        sightColor = Color.green;
        transform.position = startingPosition;
        enemySightRec.GetComponent<SpriteRenderer>();
        playerOBJ.gameObject.CompareTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        EnemeyMovement();
        EnemyDetection();
        
        sightColor.a = 0.1f;
        enemySightRec.color = sightColor;

    }


    void EnemeyMovement()
    {
        //float interpolation = elapsedPrecent / totalPrecent;

        timeToOtherSide += Time.deltaTime;

        if (timeToOtherSide < 3)
        {
            //transform.position = Vector3.Lerp(transform.position, pointB, interpolation * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x + horizontalSpeed * Time.deltaTime, transform.position.y);
        }
        
         if(timeToOtherSide > 3)
        {
            //transform.position = Vector3.Lerp(transform.position, pointA, interpolation * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x + -horizontalSpeed * Time.deltaTime, transform.position.y);
        }

        if (timeToOtherSide >= 6)
        {
            timeToOtherSide = 0;
        }

    }

    void EnemyDetection()
    {
        if(enemySight.position.x <= playerOBJ.transform.position.x + 0.6  && enemySight.position.x >= playerOBJ.transform.position.x - 0.6)
        {
            sightColor = Color.red;

            missileDelay += Time.deltaTime;
            if(missileDelay > 0.1)
            {
                missileDelay = 0.02f;
                Instantiate(missilePrefab, missileSpawn.position, transform.rotation);
            }
            
        }
        else
        {
            sightColor = Color.green;
        }

    }

   void ShootingMissile()
   {

        
   }

    
    void oldCode()
    {
        //original code for movement
        /*  if(Vector3.Distance(pointA, pointB) > totalPrecent)
          {
              Vector3.Lerp(pointB, pointA, interpolation * speed * Time.deltaTime);
          }

          if (Vector3.Distance(pointB, pointA) > totalPrecent)
          {
              Vector3.Lerp(pointA, pointB, interpolation * speed * Time.deltaTime);
          }*/ 
        
        
        // more code that moves the player smoothly
       /* if (transform.position.x <= -24)
        {

            transform.position = new Vector3(transform.position.x + hSpeed * Time.deltaTime, transform.position.y);
            
        }

        else 
        {
            transform.position = new Vector3(transform.position.x - hSpeed * Time.deltaTime, transform.position.y);

        }
       
        //  a way for the player to find the enemy
        */
       // FindObjectOfType<Player>();
       // player = FindObjectOfType<Player>().transform;

    }
}
