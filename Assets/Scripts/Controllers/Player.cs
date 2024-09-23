using Codice.CM.Common.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //public Vector3 velocity = new Vector3(0.001f, 0);

    void Update()
    {
      //  transform.position += velocity;
       
        
         PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector3 moveX = new Vector3(0.01f, 0);  //  specifies the movement of the x-axis
        Vector3 moveY = new Vector3(0, 0.01f);  // specifies the movement of the y-axis
       

        if (Input.GetKey(KeyCode.LeftArrow))  //  moves the player to the left
        {
            transform.position -= moveX;
        }

        if (Input.GetKey(KeyCode.RightArrow))  //  moves the player to the right
        {
            transform.position += moveX;
        }


        if (Input.GetKey(KeyCode.UpArrow))  //  moves the player up
        {
            transform.position += moveY;
        }


        if (Input.GetKey(KeyCode.DownArrow))  //  moves the player down
        {
            transform.position -= moveY;
        }
    }

}
