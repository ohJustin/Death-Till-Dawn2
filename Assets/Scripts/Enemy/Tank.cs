using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    override protected void Start() {
        maxHealth = 10;
        base.Start();
    }

    override public void IncreaseDiff() {
        gm.ScoreCounter += 2;
    }
}
