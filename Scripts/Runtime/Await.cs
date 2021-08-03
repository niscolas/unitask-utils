using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using CysharpUniTask = Cysharp.Threading.Tasks.UniTask;
using Object = UnityEngine.Object;

namespace niscolas.UnityUtils.UniTask
{
    public static class Await
    {
        private static GameObject _taskHolderGameObject;

        private static GameObject TaskHolderGameObject
        {
            get
            {
                if (!_taskHolderGameObject)
                {
                    _taskHolderGameObject = new GameObject("[UnityUtils.UniTask_TaskHolder]");
                    Object.DontDestroyOnLoad(_taskHolderGameObject);
                }

                return _taskHolderGameObject;
            }
        }

        public static CysharpUniTask Frames(int count, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            return Frames(count, TaskHolderGameObject, playerLoopTiming);
        }

        public static CysharpUniTask Frames
        (
            int count,
            GameObject gameObject,
            PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update
        )
        {
            return CysharpUniTask.DelayFrame
            (
                count,
                playerLoopTiming,
                gameObject.GetCancellationTokenOnDestroy()
            );
        }

        public static CysharpUniTask Seconds(float seconds)
        {
            return Seconds(seconds, TaskHolderGameObject);
        }

        public static CysharpUniTask Seconds(float seconds, GameObject gameObject)
        {
            return CysharpUniTask.Delay
            (
                TimeSpan.FromSeconds(seconds),
                cancellationToken: gameObject.GetCancellationTokenOnDestroy()
            );
        }
    }
}