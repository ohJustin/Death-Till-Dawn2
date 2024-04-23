using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
   private PlayerBase playerBase;

   private void Awake(){
        playerBase = GetComponent<PlayerBase>();
   }

   public void StartInvincibility(float invincibilityDuration){
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
   }

   private IEnumerator InvincibilityCoroutine(float invibilityDuration){
    playerBase.isInvincible = true;
    yield return new WaitForSeconds(invibilityDuration);
    playerBase.isInvincible = false;
   }

}
