using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [Serializable]
    public class WaypointWalkerStep
    {
        [SerializeField]
        private List<Waypoint> _waypoints = new List<Waypoint>();

        [SerializeField]
        private bool _startFromFirstWaypoint = true;

        [SerializeField]
        private int _playTimes;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onWaypointReached;

        [SerializeField]
        private UnityEvent _onLoopCompleted;

        [SerializeField]
        private UnityEvent _onCompleted;

        private int _currentPlayTimes;

        private bool _isCancelled;

        public List<Waypoint> Waypoints
        {
            get => _waypoints;
            set => _waypoints = value;
        }

        public bool StartFromFirstWaypoint
        {
            get => _startFromFirstWaypoint;
            set => _startFromFirstWaypoint = value;
        }

        public int PlayTimes
        {
            get => _playTimes;
            set => _playTimes = value;
        }

        public UnityEvent OnWaypointReached
        {
            get => _onWaypointReached;
            set => _onWaypointReached = value;
        }

        public UnityEvent OnLoopCompleted
        {
            get => _onLoopCompleted;
            set => _onLoopCompleted = value;
        }

        public UnityEvent OnCompleted
        {
            get => _onCompleted;
            set => _onCompleted = value;
        }

        private bool IsEndless => _playTimes <= 0;

        private bool IsStepCompleted => _currentPlayTimes <= 0;

        public event Action WaypointReached;
        public event Action LoopCompleted;
        public event Action Completed;

        public void Begin(IWaypointWalker waypointWalker)
        {
            _currentPlayTimes = _playTimes;

            Restart(waypointWalker);
        }

        private void Restart(IWaypointWalker waypointWalker)
        {
            _isCancelled = false;
            if (!CheckWaypointsAreValid(waypointWalker))
            {
                return;
            }

            MoveToInitialPosition(waypointWalker);
            CreateFollowSequence(waypointWalker);
        }

        public void Cancel()
        {
            _isCancelled = true;
        }

        private bool CheckWaypointsAreValid(IWaypointWalker waypointWalker)
        {
            if (_waypoints.IsNullOrEmpty())
            {
                Debug.LogWarning(
                    "waypoint list is not valid",
                    waypointWalker.GameObject);

                return false;
            }

            for (int i = 0; i < _waypoints.Count; i++)
            {
                if (!_waypoints[i].IsValid)
                {
                    Debug.LogWarning(
                        $"waypoint of index {i} is not valid",
                        waypointWalker.GameObject);

                    return false;
                }
            }

            return true;
        }

        private void MoveToInitialPosition(IWaypointWalker waypointWalker)
        {
            if (_startFromFirstWaypoint)
            {
                waypointWalker.WalkToInstant(_waypoints[0].Position);
            }
        }

        private void CreateFollowSequence(IWaypointWalker waypointWalker)
        {
            CreateFollowTween(waypointWalker, 0).Forget();
        }

        private async UniTaskVoid CreateFollowTween(
            IWaypointWalker waypointWalker, int waypointIndex)
        {
            if (_isCancelled)
            {
                return;
            }

            if (waypointIndex >= _waypoints.Count)
            {
                FinishLoop(waypointWalker);
                return;
            }

            Waypoint waypoint = _waypoints[waypointIndex];

            await waypointWalker.WalkTo(waypoint.Position);

            if (_isCancelled)
            {
                return;
            }

            NotifyWaypointReached();
            waypointIndex++;

            CreateFollowTween(waypointWalker, waypointIndex).Forget();
        }

        private void FinishLoop(IWaypointWalker waypointWalker)
        {
            NotifyLoopCompleted();

            if (!IsEndless)
            {
                _currentPlayTimes--;

                if (IsStepCompleted)
                {
                    NotifyCompleted();
                    return;
                }
            }

            Restart(waypointWalker);
        }

        private void NotifyWaypointReached()
        {
            WaypointReached?.Invoke();
            _onWaypointReached?.Invoke();
        }

        private void NotifyLoopCompleted()
        {
            LoopCompleted?.Invoke();
            _onLoopCompleted?.Invoke();
        }

        private void NotifyCompleted()
        {
            Completed?.Invoke();
            _onCompleted?.Invoke();
        }
    }
}