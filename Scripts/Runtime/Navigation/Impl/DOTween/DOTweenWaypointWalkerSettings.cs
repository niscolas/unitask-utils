using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [Serializable]
    public class DOTweenWaypointWalkerSettings : IWaypointWalkerData
    {
        [SerializeField]
        private BoolReference _isSpeedBased;

        [HideIf(nameof(IsSpeedBased))]
        [SerializeField]
        private FloatReference _duration;

        [ShowIf(nameof(IsSpeedBased))]
        [SerializeField]
        private FloatReference _speed;

        [SerializeField]
        private LinkBehaviour _linkBehaviour = LinkBehaviour.KillOnDisable;

        [SerializeField]
        private Ease _followEase;

        public bool IsSpeedBased => _isSpeedBased.Value;

        public Ease FollowEase => _followEase;

        public LinkBehaviour LinkBehaviour => _linkBehaviour;

        public float ComputeRealDuration()
        {
            return IsSpeedBased ? _speed.Value : _duration.Value;
        }
    }
}