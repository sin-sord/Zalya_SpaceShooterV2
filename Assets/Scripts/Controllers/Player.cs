using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector3 velocity = Vector3.zero;
   
    float speed = 2;
    Vector3 moveDirection = new Vector3(0f, 0f);
    
    public float maxSpeed = 5;
    public float accelerationTime = 3;

    private float acceleration;
    // git for prof: 100Vikings

   float timeSpeed = 10f;
   float movement;


    List<float> circlePosition = new List<float>();
    int currentPoint = 0;
    List<float> angles = new List<float>();

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        movement = timeSpeed * Time.deltaTime;

        for (int i = 0; i < 10; i++)
        {
            circlePosition.Add(Random.Range(0, 360));
        }
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        PlayerMovement();
        EnemyRadar(1, 5);
    }

    void PlayerMovement()
    {
        //Vector3 move = new Vector3(0f, 0f);
        //Vector3 moveY = new Vector3(0, 0.1f);  // specifies the movement of the y-axis
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))  //  moves the player to the left
        {
            moveDirection += Vector3.left;
            //transform.position -= moveX;
        }

        if (Input.GetKey(KeyCode.RightArrow))  //  moves the player to the right
        {
            moveDirection += Vector3.right;
            //transform.position += moveX;
        }

        if (Input.GetKey(KeyCode.UpArrow))  //  moves the player up
        {
            moveDirection += Vector3.up;
            //transform.position += moveY;
        }

        if (Input.GetKey(KeyCode.DownArrow))  //  moves the player down
        {
            moveDirection += Vector3.down;
            //transform.position -= moveY;
        }

        // This is what allows for the players movement to look smooth using acceleratoin
        if (moveDirection.magnitude == 0)
        {
            velocity += -acceleration * Time.deltaTime * velocity.normalized;
        }

        // This is what allows for the players movement to look smooth using deceleratoin
        velocity += acceleration * Time.deltaTime * moveDirection.normalized;
        transform.position += velocity * Time.deltaTime;

    }


    public void EnemyRadar(float radius, int circlePoints)
    {

        float angleInt = 360 / circlePoints;

        for (int i = 0; i < circlePoints; i++)
        {
            float distance = Vector3.Distance(transform.position, enemyTransform.position);

             if (distance < radius)
             {
                angles.Add(angleInt * i);
             }
        }

        for (int index = 1; index < angles.Count; index++)
        {
            Vector3 A = transform.position * radius;
        }
        


        /*for (int i = 0; i < circlePoints; i++)
        {
            circlePosition.Add(circlePoints);
            
            float angleInRadians = circlePosition[currentPoint] * Mathf.Deg2Rad;
            
            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);


            Vector3 playerCircle = new Vector3(transform.position.x * x, transform.position.y * y);
            Vector3 resultant = new Vector3(x, y, 0) * radius;
            Debug.DrawLine(new Vector3(transform.position.x + x, transform.position.y, 0), new Vector3(transform.position.x, transform.position.y + y, 0), Color.green);
        }*/



    }

}
