using System;
using System.Collections;
using UnityEngine;

namespace Helpers
{
    public class CoroutineExtension
    {
        public static IEnumerator Wait(float delay, Action callback = null)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }

        public static Coroutine Delay(MonoBehaviour obj, float time, Action action)
        {
            return obj.StartCoroutine(Wait(time, action));
        }

        public static Coroutine Stop(MonoBehaviour obj, Coroutine routine)
        {
            if (routine != null)
                obj.StopCoroutine(routine);

            return null;
        }
    }
}
