using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(UnityAtoms.Constants.AddComponentMenuPrefix + "Bind Int Text")]
    public class BindIntTextMonoBehaviour : BaseBindTextMonoBehaviour<
        int,
        IntPair,
        IntVariable,
        IntEvent,
        IntPairEvent,
        IntEventInstancer,
        IntEventReference,
        IntIntFunction,
        IntVariableInstancer>
    {
        protected override string FormatText(int value)
        {
            return value.ToString();
        }
    }
}