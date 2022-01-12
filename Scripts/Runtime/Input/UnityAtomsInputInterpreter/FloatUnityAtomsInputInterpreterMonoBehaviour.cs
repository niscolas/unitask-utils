using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Float" + NiceClassSuffix)]
    public class FloatUnityAtomsInputInterpreterMonoBehaviour : BaseUnityAtomsInputInterpreterMonoBehaviour<
        float,
        FloatPair,
        FloatConstant,
        FloatVariable,
        FloatEvent,
        FloatPairEvent,
        FloatEventInstancer,
        FloatEventReference,
        FloatFloatFunction,
        FloatVariableInstancer,
        FloatReference> { }
}