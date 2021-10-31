﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace niscolas.UnityUtils.Extras
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

        public static UniTask Frame(PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            return Frames(1, playerLoopTiming);
        }

        public static UniTask Frames(int count, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            return Frames(count, TaskHolderGameObject, playerLoopTiming);
        }

        public static UniTask Frames
        (
            int count,
            GameObject gameObject,
            PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update
        )
        {
            return UniTask.DelayFrame
            (
                count,
                playerLoopTiming,
                gameObject.GetCancellationTokenOnDestroy()
            );
        }

        public static UniTask Seconds(float seconds)
        {
            return Seconds(seconds, TaskHolderGameObject);
        }

        public static UniTask Seconds(float seconds, GameObject gameObject)
        {
            return UniTask.Delay
            (
                TimeSpan.FromSeconds(seconds),
                cancellationToken: gameObject.GetCancellationTokenOnDestroy()
            );
        }
    }
}
