using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public static class Utils
    {
        public static IEnumerator MakeActionDelay(float rate, Action action)
        {
            yield return new WaitForSeconds(rate);
            action.Invoke();
        }

        public static IEnumerator MakeActionDelayInfinity(float rate, Action action)
        {
            while (true)
            {
                yield return new WaitForSeconds(rate);
                action.Invoke();
            }
        }

    }
}