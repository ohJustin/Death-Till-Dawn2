using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // Reference to the player's transform
    public float rotationSpeed = 5f; // Speed of rotation
    public GameObject firePoint; // Point from where the bullets will be instantiated
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 90f; 

        Vector3 direction = mousePosition - playerTransform.position;

        float angle = - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        // Create a target rotation based on the calculated angle
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Smoothly rotate the player towards the target rotation
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
