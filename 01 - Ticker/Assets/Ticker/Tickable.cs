using UnityEngine;

namespace Ticking
{
    public abstract class Tickable : MonoBehaviour
    {
        public void StartTicker(float frequence) 
        {
            Ticker.Instance.RegisterTickable(this, frequence);
        }

        public void StopTicker() 
        {
            Ticker.Instance.StopTickable(this);
        }

        public abstract void Tick();
    }
}