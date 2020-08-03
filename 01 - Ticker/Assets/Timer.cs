using Ticking;
using UnityEngine;

public class Timer : Tickable
{
    public float frequence;

    public override void Tick()
    {
        Debug.Log("Ticker \"" + this.gameObject.name + "\" has ticked!");
    }
}
