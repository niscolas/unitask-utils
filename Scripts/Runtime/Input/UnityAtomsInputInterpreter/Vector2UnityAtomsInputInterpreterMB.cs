using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(UnityAtoms.Constants.AddComponentMenuPrefix + "Vector2" + NiceClassSuffix)]
    public class Vector2UnityAtomsInputInterpreterMB : BaseUnityAtomsInputInterpreterMB<
        Vector2,
        Vector2Pair,
        Vector2Constant,
        Vector2Variable,
        Vector2Event,
        Vector2PairEvent,
        Vector2EventInstancer,
        Vector2EventReference,
        Vector2Vector2Function,
        Vector2VariableInstancer,
        Vector2Reference> { }
}