using System.Collections;
using System.Collections.Generic;
using Ticking;
using UnityEngine;

public class TickerCompare : Tickable
{
    float frequence = 1;
    float timerTickable = 0;
    float timerUpdate = 0;

    public override void Tick()
    {
        Debug.Log("Ticker: " + (timerTickable += frequence));
        Debug.Log("Update: " + timerUpdate);
    }

    void Start()
    {
        StartTicker(frequence);    
    }

    // Update is called once per frame
    void Update()
    {
        timerUpdate += Time.deltaTime;
    }
}
