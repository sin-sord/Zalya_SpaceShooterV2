using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        directionMovement();  //  calls on the random asteroid positon at the start

    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();  //  calls the AsteroidMovement to every frame
    }

    public void AsteroidMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, moveSpeed * Time.deltaTime);  // the asteroids positon moves towards the direction set by the new method
        if(Vector3.Distance(transform.position, direction) < arrivalDistance)  //  if the asteroids arrive at the new positon...
        {
           
            transform.position = Vector3.MoveTowards(transform.position, direction, maxFloatDistance);  // make the asteroids move to another random spot
        }
    }

    public void directionMovement()  //  a new method to set the asteroid move location to be random
    {
        direction = new Vector3 // a Vector that setst the position of the asteroids to be random between the maxFloatDistance
            (transform.position.x - Random.Range(-maxFloatDistance, maxFloatDistance),
            transform.position.y - Random.Range(-maxFloatDistance, maxFloatDistance));
    }
}