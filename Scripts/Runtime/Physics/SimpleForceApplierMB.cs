using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Simple Apply Force")]
    public class SimpleForceApplierMB : CachedMB
    {
        [SerializeField]
        private FloatReference _force = new(1);

        [SerializeField]
        private ForceMode _forceMode;

        [Required]
        [SerializeField]
        private Transform _forceDirectionReference;

        public void Do(GameObject target)
        {
            if (!target.TryGetComponent(out Rigidbody targetRigidbody))
            {
                return;
            }

            targetRigidbody.AddForce(_force.Value * _forceDirectionReference.forward, _forceMode);
        }
    }
}