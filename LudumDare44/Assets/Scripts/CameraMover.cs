using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    float minX = -2;
    float maxX = 2;
    float minY = -6;
    float maxY = -2;
    public float dragSpeed = 10;
    private Vector3 oldPos;
    private Vector3 panOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPos = transform.position;
            panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);            
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
            transform.position = oldPos + -pos * dragSpeed;
        }
        CheckCameraPosition();
    }

    void CheckCameraPosition(){
        
        if(transform.position.x > maxX){
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }   else if(transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        
        if(transform.position.y > maxY){
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }   else if(transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }
}
