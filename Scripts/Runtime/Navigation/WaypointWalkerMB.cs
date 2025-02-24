﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public abstract class WaypointWalkerMB : CachedMB, IWaypointWalker
    {
        [ListDrawerSettings(NumberOfItemsPerPage = 1)]
        [SerializeField]
        private List<WaypointWalkerStep> _steps;

        [SerializeField]
        private bool _loopAll;

        [Title(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onAnyLoopCompleted;

        private int _currentIterationIndex;

        private WaypointWalkerStep _currentStep;

        public List<WaypointWalkerStep> Steps
        {
            get => _steps;
            set => _steps = value;
        }

        protected virtual void Start()
        {
            StartNextStep();
        }

        protected virtual void OnDisable()
        {
            _currentStep.Cancel();
            _currentStep.LoopCompleted -= OnAnyLoopCompleted;
            _currentStep.Completed -= OnStepCompleted;
        }

        public GameObject GameObject => _gameObject;

        public abstract void WalkToInstant(Vector3 targetPosition);

        public abstract UniTask WalkTo(Vector3 targetPosition);

        private void StartNextStep()
        {
            if (_currentIterationIndex < 0 || _currentIterationIndex >= _steps.Count)
            {
                if (_loopAll)
                {
                    _currentIterationIndex = 0;
                }
                else
                {
                    return;
                }
            }

            _currentStep = _steps[_currentIterationIndex];

            _currentStep.LoopCompleted += OnAnyLoopCompleted;
            _currentStep.Completed += OnStepCompleted;

            _currentStep.Begin(this);
        }

        private void OnAnyLoopCompleted()
        {
            _onAnyLoopCompleted?.Invoke();
        }

        private void OnStepCompleted()
        {
            _currentStep.LoopCompleted -= OnAnyLoopCompleted;
            _currentStep.Completed -= OnStepCompleted;
            _currentIterationIndex++;
            StartNextStep();
        }
    }
}