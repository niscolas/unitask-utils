using niscolas.UnityUtils.Async;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Counter Text")]
    public class CounterTextMB : AutoTriggerMB
    {
        [SerializeField]
        private SerializedCounterData _data;

        [SerializeField]
        private GameObject _textPrefab;

        [SerializeField]
        private Vector3Reference _textSpawnOffset = new Vector3Reference();

        [Required]
        [SerializeField]
        private ServiceBasedSpawnStrategySO _spawnStrategy;

        public override void Do()
        {
            CounterTextUtility
                .StartCountingWithText(
                    _data.From,
                    _data.To,
                    _textPrefab,
                    _ => _transform.position + _textSpawnOffset.Value,
                    _spawnStrategy.Service,
                    i => _data.OnTick?.Invoke(i),
                    () => _data.OnFinished?.Invoke())
                .Forget();
        }

        public void DoAtGameObjectPosition(GameObject target)
        {
            CounterTextUtility
                .StartCountingWithText(
                    _data.From,
                    _data.To,
                    _textPrefab,
                    _ => target.transform.position + _textSpawnOffset.Value,
                    _spawnStrategy.Service,
                    i => _data.OnTick?.Invoke(i),
                    () => _data.OnFinished?.Invoke())
                .Forget();
        }
    }
}