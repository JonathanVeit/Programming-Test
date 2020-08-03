using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ticking
{
    public class Ticker : Singleton<Ticker>
    {
        // Tickable Instance + Coroutine Instance
        Dictionary<Tickable, Coroutine> allTickables = new Dictionary<Tickable, Coroutine>();

        public void RegisterTickable(Tickable tickable, float frequence) 
        {
            if (!allTickables.ContainsKey(tickable))
            {
                // new entry for Tickable and Coroutine
                allTickables.Add(tickable, StartCoroutine(UpdateProcess(tickable, frequence)));
            }
            else
                Debug.LogWarning("Tickable is already registered!", tickable);
        }

        public void StopTickable(Tickable tickable) 
        {
            if (allTickables.ContainsKey(tickable))
            {
                // stop Coroutine
                StopCoroutine(allTickables[tickable]);

                // remove entry
                allTickables.Remove(tickable);
            }
            else
                Debug.LogWarning("Tickable has not been registered!", tickable);
        }

        IEnumerator UpdateProcess(Tickable target, float frequence ) 
        {
            WaitForSeconds wait = new WaitForSeconds(frequence);

            while (true)
            {
                yield return wait;
                target.Tick();
            }
        }
    }
}
