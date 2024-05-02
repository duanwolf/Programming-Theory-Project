using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Animal
{
     void Start()
    {
        TimeRemain = 3f;
    }
    public override void Walk()
    {
        base.Walk();
    }

    public override void DestroyCheck()
    {
        TimeAliveCheck();
    }
}
