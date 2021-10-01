using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	[CreateAssetMenu(menuName = Constants.CreateAssetMenuPrefix + "Unity Instantiate Strategy")]
	public class UnityInstantiateStrategy : ServiceBasedSpawnStrategy<UnityInstantiateService> { }
}