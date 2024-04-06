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
        Vector3 tempPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, obj.transform.position.z);
        obj.transform.position = tempPos;
    }


}
