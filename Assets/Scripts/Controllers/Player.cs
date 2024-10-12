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

    public GameObject powerUpPrefab;

    public float detectionRadius;



    public Vector3 velocity = Vector3.zero;

    float speed = 2;
    Vector3 moveDirection = new Vector3(0f, 0f);

    public float maxSpeed = 5;
    public float accelerationTime = 3;

    private float acceleration;
    // git for prof: 100Vikings

    float timeSpeed = 10f;
    float movement;

    // color of the line and the number of points
    Color lineColor = Color.green;
    public int circlePoints;

    // radius and number of power ups:
    public int powerUpPoints;
    public float powerUpRadius;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        movement = timeSpeed * Time.deltaTime;

    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        PlayerMovement();
        EnemyRadar(detectionRadius, circlePoints);



        if (Input.GetKeyDown(KeyCode.P))  //  if the P key is pressed
        {
            SpawnPowerups(powerUpRadius, powerUpPoints);  //  spawn the power ups

        }

    }

    void PlayerMovement()
    {
        //Vector3 move = new Vector3(0f, 0f);
        //Vector3 moveY = new Vector3(0, 0.1f);  // specifies the movement of the y-axis
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))  //  moves the player to the left
        {
            moveDirection += Vector3.left;
            //transform.position -= moveX;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))  //  moves the player to the right
        {
            moveDirection += Vector3.right;
            //transform.position += moveX;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))  //  moves the player up
        {
            moveDirection += Vector3.up;
            //transform.position += moveY;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))  //  moves the player down
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
        List<float> listOfPoints = new List<float>();  //  List that holds points
        float setPoint = 360 / circlePoints;  //  a way to calculate the circle for where the power ups will spawn




        for (int index = 0; index <= circlePoints; index++)  //  a loop that has a second loop draw lines to each point, this loop sets the number of points
        {
            listOfPoints.Add(setPoint * index);

            for (int pointsCount = 1; pointsCount < listOfPoints.Count; pointsCount++)  //  a loop that draws the lines to each point
            {
                Vector3 firstPointsPosition = new Vector3(Mathf.Cos(listOfPoints[pointsCount - 1] * Mathf.Deg2Rad) * radius,  //  draws a line from the start of a point
                    Mathf.Sin(listOfPoints[pointsCount - 1] * Mathf.Deg2Rad) * radius);
                
                Vector3 nextPointsPosition = new Vector3(Mathf.Cos(listOfPoints[pointsCount] * Mathf.Deg2Rad) * radius,  //  draws a line to the end of a point
                    Mathf.Sin(listOfPoints[pointsCount] * Mathf.Deg2Rad) * radius);


                Vector3 startLine = transform.position + firstPointsPosition;
                Vector3 endLine = transform.position + nextPointsPosition;

                Debug.DrawLine(startLine, endLine, lineColor);  //  draws the line
            }

        }

        if (Vector3.Distance(transform.position, enemyTransform.position) <= radius)  //  if the enemy is within the radius, the line changes to red
        {
            lineColor = Color.red;
        }
        else
        {
            lineColor = Color.green;
        }
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        List<float> powerUpList = new List<float>();  //  a list that stores the number of power ups
        float setPowerUp = 360 / numberOfPowerups;  //  a way to calculate the circle for where the power ups will spawn

        for (int index = 0; index <= numberOfPowerups; index++)  //  a loop that adds to the list
        {
            powerUpList.Add(setPowerUp * index);

        }
        for (int powerUpCount = 1; powerUpCount < powerUpList.Count; powerUpCount++)  //  a loop that  initiates the list by starting at 1 to make the power ups spawn
        {
            Vector3 PowerUpLocation = new Vector3(Mathf.Cos(powerUpList[powerUpCount - 1] * Mathf.Deg2Rad) * radius,  //  sets the position of the power ups
                Mathf.Sin(powerUpList[powerUpCount - 1] * Mathf.Deg2Rad) * radius);

            Vector3 powerUpPosition = transform.position + PowerUpLocation;

            Debug.Log("Powerup spawned!");

            Instantiate(powerUpPrefab, powerUpPosition, Quaternion.identity);  //  spawns the power ups at the set position

            //Debug.Log("Powerup spawned!");
        }

    }
}
