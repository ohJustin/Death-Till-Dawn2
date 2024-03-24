using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer{ get; private set; } //indicates if enemy is aware of player. 'set private... only allowing this script to set value'

    public Vector2 DirectionToPlayer { get; private set; } //Useful for enemy to know player's direction.

    [SerializeField]
    private float _playerAwarenessDistance; //Distance from which enemy notices player.

    private Transform _player; //transform for our player.

    // Start is called before the first frame update
    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform; //Only player has PlayerMovement component.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position; //Tells us how far player is and the direction.

        DirectionToPlayer = enemyToPlayerVector.normalized; //normalized -> just gives us the direction, but sets magnitude to 1.

        if(enemyToPlayerVector.magnitude <= _playerAwarenessDistance){
            AwareOfPlayer = true; //Player is within distance set in fields.
        }
        else{
            AwareOfPlayer = false; //Player is not.
        }
    }
}
