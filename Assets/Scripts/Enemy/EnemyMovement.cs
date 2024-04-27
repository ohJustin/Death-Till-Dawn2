using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    protected float _speed; // Enemy speed.
    [SerializeField]    
    protected float _rotationSpeed; // Enemy rotation speed.

    protected Rigidbody2D _rigidbody; // Enemy rigidbody.
    protected PlayerAwarenessController _playerAwarenessController; // Go to 'PlayerAwarenessController' class.
    protected Vector2 _targetDirection;
    protected float _changeDirectionCooldown; // amount of time remaining until next direction change
    public Vector3 endPos;


    public bool isThrown = false;

    // Start is called before the first frame update
    protected void Awake(){

        // Gets rigid2D body component and assigns it the field.
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void FixedUpdate(){

        if(isThrown) {
            Thrown();
            return;
        }

        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    protected void UpdateTargetDirection(){
        // Wander randomly unless detects player
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        
    }

    protected void HandleRandomDirectionChange() {
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

    protected void HandlePlayerTargeting() {
        if(_playerAwarenessController.AwareOfPlayer){
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }

    protected void RotateTowardsTarget(){
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,  targetRotation, _rotationSpeed * Time.deltaTime);
        
        //Apply rotation to rigidbody.
        _rigidbody.SetRotation(rotation);
    }

    protected void SetVelocity(){
        _rigidbody.velocity = transform.up * _speed;
    }

    protected void Thrown() {
        if(transform.position.x - endPos.x > .1f || transform.position.x - endPos.x < -.1f) {
            transform.position = Vector3.MoveTowards(transform.position, endPos, 0.5f);
            Debug.Log("throw");
        }
        else {
            isThrown = false;
        }
    }
}
