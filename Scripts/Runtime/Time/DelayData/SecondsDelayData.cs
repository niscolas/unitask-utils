using System;
using UnityEngine;
using CysharpUniTask = Cysharp.Threading.Tasks.UniTask;

namespace niscolas.UnityUtils.UniTask
{
    [Serializable]
    public class SecondsDelayData
    {
        [SerializeField]
        private float _count = 1;

        public CysharpUniTask Wait()
        {
            return Await.Seconds(_count);
        }
        
        public CysharpUniTask Wait(GameObject gameObject)
        {
            return Await.Seconds(_count, gameObject);
        }
    }
}