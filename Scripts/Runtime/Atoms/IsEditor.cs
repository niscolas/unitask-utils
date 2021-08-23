using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
    [CreateAssetMenu(
        menuName = Constants.ConditionsCreateAssetMenuPath + "() => Is Editor?")]
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