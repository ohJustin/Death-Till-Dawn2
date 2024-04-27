using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : EnemyMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override protected void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
    }
}
