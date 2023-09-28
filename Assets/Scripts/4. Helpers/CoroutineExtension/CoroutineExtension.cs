using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    public class CoroutineExtension
    {
        private static IEnumerator Wait(float delay, Action callback = null)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }

        private static IEnumerator RepeatAction(Func<bool> condition, Action repeatAction, float delay = 0, Action callback = null)
        {
            while (condition.Invoke())
            {
                if (delay == 0)
                    yield return null;
                else
                    yield return new WaitForSeconds(delay);

                repeatAction?.Invoke();
            }
            callback?.Invoke();
        }

        public static Coroutine Delay(MonoBehaviour obj, float time, Action action)
        {
            return obj.StartCoroutine(Wait(time, action));
        }

        public static Coroutine RepeatUntil(MonoBehaviour obj, Func<bool> condition, Action repeatAction, float delay = 0, Action callback = null)
        {
            return obj.StartCoroutine(RepeatAction(condition, repeatAction, delay, callback));
        }

        public static Coroutine Stop(MonoBehaviour obj, Coroutine routine)
        {
            if (routine != null)
                obj.StopCoroutine(routine);

            return null;
        }
    }
}
