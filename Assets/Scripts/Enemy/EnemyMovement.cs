using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed; // Enemy speed.
    [SerializeField]    
    private float _rotationSpeed; // Enemy rotation speed.

    private Rigidbody2D _rigidbody; // Enemy rigidbody.
    private PlayerAwarenessController _playerAwarenessController; // Go to 'PlayerAwarenessController' class.
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown; // amount of time remaining until next direction change

    // Start is called before the first frame update
    private void Awake(){

        // Gets rigid2D body component and assigns it the field.
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){

        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection(){
        // Wander randomly unless detects player
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        
    }

    private void HandleRandomDirectionChange() {
        _changeDirectionCooldown -= Time.deltaTime;
        // If cool down is complete
        if (_changeDirectionCooldown <= 0) {
            // create a random angle
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;
            // Set cool down again after direction change complete
            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting() {
        if(_playerAwarenessController.AwareOfPlayer){
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget(){
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,  targetRotation, _rotationSpeed * Time.deltaTime);
        
        //Apply rotation to rigidbody.
        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity(){
        _rigidbody.velocity = transform.up * _speed;
    }

}
