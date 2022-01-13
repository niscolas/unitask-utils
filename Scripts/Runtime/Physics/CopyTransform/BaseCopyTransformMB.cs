using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public abstract class BaseCopyTransformMB : CachedMonoBehaviour
    {
        [SerializeField]
        private ReferenceOrTag<Transform> _copyTarget;

        protected abstract void CopyTransform(Transform copyTarget);

        private void FixedUpdate()
        {
            Transform copyTargetValue = _copyTarget.Value;
            if (!copyTargetValue)
            {
                return;
            }

            CopyTransform(copyTargetValue);
        }
    }
}