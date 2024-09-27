using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Configuration;


public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;

    private void Start()
    {
    }

    void Update()
    {
        detector(4.5f, 7);
    }

    void detector(float inRangeOfEnemy, float nearEnemy)
    {
        Vector3 enemyPos = transform.position; //  a Vector3 that defines the enemy position
        Vector3 playerPos = player.transform.position; //  a Vector3 that defines the player position


        float distanceRange = Vector3.Distance(playerPos, enemyPos);  // a variable that measures the distance between the two vector3's

        if(distanceRange < nearEnemy)
        {
            Debug.DrawLine(playerPos, enemyPos, Color.yellow);
        }
   
        if (distanceRange < inRangeOfEnemy)  //  if the players distance and is near the enemy and within the set range...
        {
            transform.Rotate(Vector3.forward, player.transform.position.x + speed * Time.deltaTime);  //  make the enemy rotate
            Debug.DrawLine(playerPos, enemyPos, Color.red);  //  draw a red line to represent the player is getting close

        }
    }

}
