using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regularFish : Fish
{
    void Start()
    {
        points = 1;
    }

    public override void destroyFish()
    {
        Destroy(gameObject);
    }
}
