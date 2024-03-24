using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed; //Enemy speed.
    [SerializeField]    
    private float _rotationSpeed; //Enemy rotation speed.

    private Rigidbody2D _rigidbody; //Enemy rigidbody.
    private PlayerAwarenessController _playerAwarenessController; //Go to 'PlayerAwarenessController' class.
    private Vector2 _targetDirection;

    // Start is called before the first frame update
    private void Awake(){

        //Gets rigid2D body component and assigns it the field.
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
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

        if(_playerAwarenessController.AwareOfPlayer){
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }else{
            _targetDirection = Vector2.zero;
        }

    }

    private void RotateTowardsTarget(){
        if(_targetDirection == Vector2.zero){
            return;
        }//If there is a target direction, we'll calculate the target's rotation.
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,  targetRotation, _rotationSpeed * Time.deltaTime);
        
        //Apply rotation to rigidbody.
        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity(){

        if(_targetDirection == Vector2.zero){ //Make sure target-direction hasn't already been set.
            _rigidbody.velocity = Vector2.zero;
        }else{//If we have a target direction.
            _rigidbody.velocity = transform.up * _speed;
        }

    }



}
