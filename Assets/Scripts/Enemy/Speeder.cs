using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeder : EnemyBase
{
    override protected void Start() {
        maxHealth = 2;
        base.Start();
    }
}
