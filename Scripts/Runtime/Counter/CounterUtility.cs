using System;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using TMPro;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public static class CounterUtility
    {
        public static async UniTask StartCounting(
            int from,
            int to,
            Action<int> callback,
            Action finishedCallback = null,
            float firstTickTimeInterval = 0,
            float timeInterval = 1)
        {
            await Await.Seconds(firstTickTimeInterval);

            foreach (int i in from.EnumerableFor(to))
            {
                callback(i);
                await Await.Seconds(timeInterval);
            }

            finishedCallback?.Invoke();
        }

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

            await StartCounting(
                from, to, Callback, finishedCallback, firstTickTimeInterval, timeInterval);
            finishedCallback?.Invoke();
        }
    }
}