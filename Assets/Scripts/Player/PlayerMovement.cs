using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

   [SerializeField]
   private float speed;
   [SerializeField]
   private float _rotationSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput; //Unity's Vector2 SmoothDamp Method.
    private Vector2 _movementInputSmoothVelocity; //Keeps track of velocity to change. Go to fixedupdate.
    static public PlayerMovement    S;  //Go to awake function.
    // Start is called before the first frame update

    void Awake(){ 
        _rigidbody = GetComponent<Rigidbody2D>(); //Finds rigidbody attached to game obj. And retrieves it.


       
        if(S == null){ // Given we plan on adding different levels&scenes-
            S = this; //  I added a failsafe in case of any player loading errors.
        }
        else{
            Debug.LogError("Player.Awake() - Attempted to assign second Player.S!!!");
        }

    }

   

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    private void FixedUpdate(){//Any changes to rigidbody reccomended to be made in FixedUpdate()
            SetPlayerVelocity();
            RotateInDirectionOfInput();
    }

    private void RotateInDirectionOfInput(){ //Handles rotation of sprite during movement.
    //Quaternion is a type specifically for rotation.

        if(_movementInput != Vector2.zero){// check if player moving. then rotate in that direction.
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
    private void SetPlayerVelocity(){ //Creates smooth & saemless movement when using WASD's
        //Object moves at 1 unit per second on the x axis, and 0.5 on the y axis.
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, 0.1f);   
         _rigidbody.velocity = _smoothedMovementInput * speed; 
    }

    private void OnMove(InputValue inputValue){//provided by installed Input System... UnityEngine.InputSystem
        _movementInput = inputValue.Get<Vector2>();
    }
}
