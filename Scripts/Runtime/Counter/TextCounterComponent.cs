using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class TextCounterComponent : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private SerializedCounterData _data;

        [SerializeField]
        private GameObject _textPrefab;

        [SerializeField]
        private Vector3Reference _textSpawnOffset = new Vector3Reference();

        [Required, SerializeField]
        private ServiceBasedSpawnStrategySO _spawnStrategy;

        public override void Do()
        {
            CounterUtility
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
            CounterUtility
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