using System.Collections.Generic;
using System.Data;
using UnityEngine;

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


    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }

    void Update()
    {
    //    transform.position += velocity * Time.deltaTime;
               
        PlayerMovement();
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

/*      transform.position += moveX * Time.deltaTime;
        transform.position -= moveX * Time.deltaTime;
        transform.position += moveY * Time.deltaTime;
        transform.position -= moveY * Time.deltaTime;*/
    }

}
