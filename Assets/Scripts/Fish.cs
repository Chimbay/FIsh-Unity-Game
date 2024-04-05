using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Fish : MonoBehaviour
{
    // Fields
    // Store how many points for child class
    protected int points;

    // Store point value
    public int PointValue { get { return points; } }

    // Abstract class to have derived classes have their own form of destroying
    public abstract void destroyFish();
}
