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

    Color lineColor = Color.green;
    public int circlePoints;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        movement = timeSpeed * Time.deltaTime;

    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        PlayerMovement();
        EnemyRadar(1, circlePoints);
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
        List<float> listOfPoints = new List<float>();
        float setPoint = 360 / circlePoints;

        for(int index = 0; index <= circlePoints; index++)
        {
            listOfPoints.Add(setPoint * index);

            for(int pointsCount = 1; pointsCount < listOfPoints.Count; pointsCount++)
            {
                Vector3 startLine = transform.position + new Vector3(Mathf.Cos(listOfPoints[pointsCount - 1] * Mathf.Deg2Rad * radius),Mathf.Sin(listOfPoints[pointsCount - 1] * Mathf.Deg2Rad * radius));

                Vector3 endLine = transform.position + new Vector3(Mathf.Cos(listOfPoints[pointsCount] * Mathf.Deg2Rad * radius), Mathf.Sin(listOfPoints[pointsCount] * Mathf.Deg2Rad * radius));

                Debug.DrawLine(startLine, endLine, lineColor);
            }

        }

        if(Vector3.Distance(transform.position, enemyTransform.position) <= radius)
        {
            lineColor = Color.red;
        }
        else
        {
            lineColor = Color.green;
        }
    }

}
