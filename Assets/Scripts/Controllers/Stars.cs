using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public float completeTime = 2;


    private void Start()
    {
        starTransforms[0] = starTransforms[0];
        starTransforms[1] = starTransforms[1];
        starTransforms[2] = starTransforms[2];
        starTransforms[3] = starTransforms[3];
        starTransforms[4] = starTransforms[4];
        starTransforms[5] = starTransforms[5];
        starTransforms[6] = starTransforms[6];
        starTransforms[7] = starTransforms[7];
        starTransforms[8] = starTransforms[8];

    }

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        drawingTime += Time.deltaTime;
        float timeCompleted = drawingTime / completeTime;

        Transform star0 = starTransforms[0];
        Transform star1 = starTransforms[1];
        Transform star2 = starTransforms[2];
        Transform star3 = starTransforms[3];
        Transform star4 = starTransforms[4];
        Transform star5 = starTransforms[5];
        Transform star6 = starTransforms[6];
        Transform star7 = starTransforms[7];
        Transform star8 = starTransforms[8];

        

        foreach (Transform t in starTransforms)
        {
            Vector3 endPosition = Vector3.Lerp(star0.position, star1.position, drawingTime);
            Debug.DrawLine(star0.position, endPosition, Color.white, 2);

            if(drawingTime > 2)
            {
                Vector3 endposition1 = Vector3.Lerp(endPosition, star2.position, drawingTime);
                Debug.DrawLine(endPosition, endposition1, Color.white, 2);

            }
            
            if(drawingTime > 3)
            {
                Vector3 endposition2 = Vector3.Lerp(star2.position, star3.position, drawingTime);
                Debug.DrawLine(star2.position, endposition2, Color.white, 2);
            }
            
            if(drawingTime > 4)
            {
                Vector3 endposition3 = Vector3.Lerp(star3.position, star4.position, drawingTime);
                Debug.DrawLine(star3.position, endposition3, Color.white, 2);
            }
            
            if(drawingTime > 5)
            {
                Vector3 endposition4 = Vector3.Lerp(star4.position, star5.position, drawingTime);
                Debug.DrawLine(star4.position, endposition4, Color.white, 2);
            }
            
            if(drawingTime > 6)
            {
                Vector3 endposition5 = Vector3.Lerp(star5.position, star6.position, drawingTime);
                Debug.DrawLine(star5.position, endposition5, Color.white, 2);
            }
            
            if(drawingTime > 7)
            {
                Vector3 endposition6 = Vector3.Lerp(star6.position, star7.position, drawingTime);
                Debug.DrawLine(star6.position, endposition6, Color.white, 2);
            }
        }
        
    }
}
