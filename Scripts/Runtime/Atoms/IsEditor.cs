using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.ConditionsCreateAssetMenuPrefix + "() => Is Editor?")]
    public class IsEditor : VoidCondition
    {
        [SerializeField]
        private bool invert;

        public override bool Call()
        {
            return invert ? !Application.isEditor : Application.isEditor;
        }
    }
}