using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(float) => Set Material Float Property")]
    public class SetMaterialFloatPropertyDynamicAtomAction : AtomAction<float>
    {
        [SerializeField]
        private StringReference _propertyName;
        
        [SerializeField]
        private Material _material;
        
        public override void Do(float value)
        {
            _material.SetFloat(_propertyName.Value, value);
        }
    }
}