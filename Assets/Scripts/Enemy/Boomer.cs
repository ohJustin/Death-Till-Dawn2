using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : EnemyBase
{

    [SerializeField]
    private GameObject poolPrefab;


    override protected void Start() {
        maxHealth = 4;
        base.Start();
    }

    override public void IncreaseDiff() {
        gm.ScoreCounter += 3;
    }

    public void Boom() {
        GameObject obj = Instantiate(poolPrefab);
        obj.transform.position = gameObject.transform.position;
    }


}
