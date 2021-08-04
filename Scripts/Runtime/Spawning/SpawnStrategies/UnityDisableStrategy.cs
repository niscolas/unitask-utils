using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	[CreateAssetMenu(menuName = Constants.CreateAssetMenuPathPrefix + "Unity Disable Strategy")]
	public class UnityDisableStrategy : ServiceBasedDespawnStrategy<UnityDisableService> { }
}