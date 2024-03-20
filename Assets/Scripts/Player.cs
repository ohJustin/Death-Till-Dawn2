using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
   private float speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    static public Player    S;  //Go to awake function.
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
    
    private void FixedUpdate(){
            //Any changes to rigidbody reccomended to be made in FixedUpdate()

            //Object moves at 1 unit per second on the x axis, and 0.5 on the y axis.
            _rigidbody.velocity = _movementInput * speed; 
    }

    private void OnMove(InputValue inputValue){//provided by installed Input System... UnityEngine.InputSystem
        _movementInput = inputValue.Get<Vector2>();
    }
}
