using System.Globalization;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(UnityAtoms.Constants.AddComponentMenuPrefix + "Bind Float Text")]
    public class BindFloatTextMonoBehaviour : BaseBindTextMonoBehaviour<
        float,
        FloatPair,
        FloatVariable,
        FloatEvent,
        FloatPairEvent,
        FloatEventInstancer,
        FloatEventReference,
        FloatFloatFunction,
        FloatVariableInstancer>
    {
        protected override string FormatText(float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}