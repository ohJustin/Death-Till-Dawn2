using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    public float _invincibilityDuration;

    private InvincibilityController _invincibilityController;

    public void Awake(){
        _invincibilityController = GetComponent<InvincibilityController>();
    }
   public void StartInvincibility(){
        _invincibilityController.StartInvincibility(_invincibilityDuration);
   }
}
