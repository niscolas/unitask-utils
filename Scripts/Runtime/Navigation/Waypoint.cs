using System;
using UnityEngine;

namespace BestLostNFound
{
    [Serializable]
    public struct Waypoint
    {
        [SerializeField]
        private Transform _point;

        public bool IsValid => _point;
        public Vector3 Position => _point.position;
    }
}
