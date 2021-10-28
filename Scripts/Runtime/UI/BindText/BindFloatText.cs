using System.Globalization;
using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms.BaseAtoms;

namespace niscolas.UnityUtils.Extras
{
    public class BindFloatText : BaseBindText<
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