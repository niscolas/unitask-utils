using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class OverwriteRigidbodyMass : AutoTriggerMonoBehaviour
    {
        [Required, SerializeField]
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