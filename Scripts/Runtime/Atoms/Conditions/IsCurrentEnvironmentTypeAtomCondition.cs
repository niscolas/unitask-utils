using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(menuName =
        UnityAtomsConstants.ConditionsCreateAssetMenuPrefix + "() => Is Current " + nameof(EnvironmentType) + "?")]
    public class IsCurrentEnvironmentTypeAtomCondition : VoidCondition
    {
        [SerializeField]
        private EnvironmentType _testGameEnvironment;

        public override bool Call()
        {
            return _testGameEnvironment.IsCurrentEnvironment();
        }
    }
}