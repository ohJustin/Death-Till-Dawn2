using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset; // Offset between the camera and the player

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
