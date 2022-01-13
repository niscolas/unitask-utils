using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Override Rigidbody Mass")]
    public class OverrideRigidbodyMassMB : AutoTriggerMB
    {
        [Required]
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private FloatReference _mass;

        public override void Do()
        {
            _gameObject.IfUnityNullGetComponent(ref _rigidbody);

            if (!_rigidbody)
            {
                return;
            }

            _rigidbody.mass = _mass.Value;
        }
    }
}