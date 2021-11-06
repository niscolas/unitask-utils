using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Serialization;

namespace niscolas.UnityUtils.Extras
{
    public class ScaleSlider : CachedMonoBehaviour
    {
        [FormerlySerializedAs("_fillTransform"), SerializeField]
        private Transform _fill;

        [SerializeField]
        private FloatReference _minScale = new FloatReference(0);

        [SerializeField]
        private FloatReference _maxScale = new FloatReference(1f);

        [EnumToggleButtons, SerializeField]
        private Axis _affectedAxes;

        private Transform Fill
        {
            get
            {
                if (!_fill)
                {
                    _fill = transform;
                }

                return _fill;
            }
        }

        [Title("Debug")]
        [Button]
        public void SetFill(float ratio)
        {
            float fill = (_maxScale.Value - _minScale.Value) * ratio + _minScale.Value;

            Vector3 localScale = Fill.localScale;
            if (_affectedAxes.BitmaskEnumContainsValue(Axis.X))
            {
                localScale.x = fill;
            }

            if (_affectedAxes.BitmaskEnumContainsValue(Axis.Y))
            {
                localScale.y = fill;
            }

            if (_affectedAxes.BitmaskEnumContainsValue(Axis.Z))
            {
                localScale.z = fill;
            }

            Fill.localScale = localScale;
        }
    }
}