using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Constants = niscolas.UnityUtils.UnityAtoms.Constants;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(menuName = Constants.FunctionsFolderPath + "(GameObject) => Select Root : GameObject")]
    public class SelectRootAtom : GameObjectGameObjectFunction
    {
        public override GameObject Call(GameObject gameObject)
        {
            return gameObject.Root();
        }
    }
}