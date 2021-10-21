using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.FunctionsCreateAssetMenuPrefix + "(GameObject) => Select Root : GameObject")]
    public class SelectRootAtomFunction : GameObjectGameObjectFunction
    {
        public override GameObject Call(GameObject gameObject)
        {
            return gameObject.Root();
        }
    }
}