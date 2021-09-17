using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
	[CreateAssetMenu(menuName = Constants.CreateAssetMenuPathPrefix + "Unity Disable Strategy")]
	public class UnityDisableStrategy : ServiceBasedDespawnStrategy<UnityDisableService> { }
}