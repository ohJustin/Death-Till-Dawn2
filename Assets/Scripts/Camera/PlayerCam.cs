using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{   
    // Point of interest
    public Transform player; 
    // Offset between the camera and the player if we want.
    public Vector3 offset;

    void FixedUpdate()
    {
        if (player != null)
        {
            // Calculate the target position for the camera
            Vector3 targetPosition = player.position + offset;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }
    }
}
