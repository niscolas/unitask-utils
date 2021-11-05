using UnityAtoms.MonoHooks;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.FunctionsCreateAssetMenuPrefix + "(GameObject) => Select Child : GameObject")]
    public class SelectFirstChildAtomFunction : GameObjectGameObjectFunction
    {
        public override GameObject Call(GameObject entry)
        {
            if (!entry || entry.transform.childCount == 0) return default;

            Transform child = entry.transform.GetChild(0);

            if (!child) return default;

            return child.gameObject;
        }
    }
}