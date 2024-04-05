using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodingFish : Fish
{
    void Start()
    {
        points = 3;
    }

    public override void destroyFish()
    {
        Destroy(gameObject);
    }
}
