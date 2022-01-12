using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = Core.Constants.CoreCreateAssetMenuPrefix + "Unity Disable Strategy",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class UnityDisableStrategySo : ServiceBasedDespawnStrategySO<UnityDisableService> { }
}