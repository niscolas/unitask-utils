using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = Constants.CreateAssetMenuPrefix + "Unity Disable Strategy",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class UnityDisableStrategy : ServiceBasedDespawnStrategy<UnityDisableService> { }
}