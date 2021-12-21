using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.FunctionsCreateAssetMenuPrefix + "(GameObject) => Select Parent : GameObject")]
    public class SelectParentAtomFunction : GameObjectGameObjectFunction
    {
        public override GameObject Call(GameObject gameObject)
        {
            return gameObject.transform.parent.gameObject;
        }
    }
}