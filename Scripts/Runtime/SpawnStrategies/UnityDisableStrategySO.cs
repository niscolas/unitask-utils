using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = Core.Constants.CreateAssetMenuPrefix + "Unity Disable Strategy",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class UnityDisableStrategySO : ServiceBasedDespawnStrategySO<UnityDisableService> { }
}