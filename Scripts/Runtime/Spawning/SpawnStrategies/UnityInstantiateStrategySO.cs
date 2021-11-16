using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
    [CreateAssetMenu(menuName = Constants.CoreCreateAssetMenuPrefix + "Unity Instantiate Strategy")]
    public class UnityInstantiateStrategySO : ServiceBasedSpawnStrategySO<UnityInstantiateService> { }
}