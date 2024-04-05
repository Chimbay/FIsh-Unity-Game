using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burningFish : animatedFish
{
    void Start()
    {
        points = 2;
    }

    public override void destroyFish()
    {
        Destroy(gameObject);
    }
}
