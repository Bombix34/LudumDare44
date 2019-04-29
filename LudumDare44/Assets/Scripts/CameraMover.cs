using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
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
        if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // forward
        {
            if(!IsVectorVisible(Camera.main.WorldToViewportPoint(new Vector3(DescentContainer.Instance.SpaceUsed.x, DescentContainer.Instance.SpaceUsed.y))) 
            || !IsVectorVisible(Camera.main.WorldToViewportPoint(new Vector3(DescentContainer.Instance.SpaceUsed.z, DescentContainer.Instance.SpaceUsed.w)))){
                Camera.main.orthographicSize++;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // backwards
        {
            if(Camera.main.orthographicSize > 2.2){
                Camera.main.orthographicSize--;
            }
        }
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (Camera.main.orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                Camera.main.orthographicSize += deltaMagnitudeDiff * dragSpeed;

                // Make sure the orthographic size never drops below zero.
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                Camera.main.fieldOfView += deltaMagnitudeDiff * dragSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }
        CheckCameraPosition();
    }

    private bool IsVectorVisible(Vector3 vect){
        return vect.x >= 0 && vect.x <= 1 && vect.y >= 0 && vect.y <= 1 && vect.z > 0;
    }

    void CheckCameraPosition(){
        
        if(transform.position.x > DescentContainer.Instance.SpaceUsed.z){
            transform.position = new Vector3(DescentContainer.Instance.SpaceUsed.z, transform.position.y, transform.position.z);
        }   else if(transform.position.x < DescentContainer.Instance.SpaceUsed.x)
        {
            transform.position = new Vector3(DescentContainer.Instance.SpaceUsed.x, transform.position.y, transform.position.z);
        }
        
        if(transform.position.y > DescentContainer.Instance.SpaceUsed.w){
            transform.position = new Vector3(transform.position.x, DescentContainer.Instance.SpaceUsed.w, transform.position.z);
        }   else if(transform.position.y < DescentContainer.Instance.SpaceUsed.y)
        {
            transform.position = new Vector3(transform.position.x, DescentContainer.Instance.SpaceUsed.y, transform.position.z);
        }
    }
}
