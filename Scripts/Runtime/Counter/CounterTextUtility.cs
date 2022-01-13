using System;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Async;
using niscolas.UnityUtils.Core;
using TMPro;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public static class CounterTextUtility
    {
        public static async UniTaskVoid StartCountingWithText(
            int from,
            int to,
            GameObject prefab,
            Func<int, Vector3> spawnPositionProvider,
            ISpawnService spawnService,
            Action<int> callback = null,
            Action finishedCallback = null,
            float firstTickTimeInterval = 0,
            float timeInterval = 1)
        {
            void Callback(int i)
            {
                callback?.Invoke(i);

                TMP_Text text = spawnService
                    .Spawn(
                        prefab,
                        spawnPositionProvider.Invoke(i),
                        Quaternion.identity)
                    .GetComponentInChildren<TMP_Text>();

                if (!text)
                {
                    return;
                }

                text.SetText($"{i}");
            }

            await CounterUtility.StartCounting(
                from, to, Callback, finishedCallback, firstTickTimeInterval, timeInterval);
            finishedCallback?.Invoke();
        }
    }
}