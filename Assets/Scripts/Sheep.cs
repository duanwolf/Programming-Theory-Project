using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance from Animal

public class Sheep : Animal
{
    // POLYMORPHISM
    public override void Walk()
    {
        WalkingTime = 2f;
    }

}
