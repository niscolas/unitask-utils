using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using CysharpUniTask = Cysharp.Threading.Tasks.UniTask;

namespace niscolas.UnityUtils.UniTask
{
    [Serializable]
    public class FramesDelayData
    {
        [SerializeField]
        private int _count = 1;

        [SerializeField]
        private PlayerLoopTiming _playerLoopTiming = PlayerLoopTiming.Update;

        public CysharpUniTask Wait()
        {
            return Await.Frames(_count, _playerLoopTiming);
        }

        public CysharpUniTask Wait(GameObject gameObject)
        {
            return Await.Frames(_count, gameObject, _playerLoopTiming);
        }
    }
}