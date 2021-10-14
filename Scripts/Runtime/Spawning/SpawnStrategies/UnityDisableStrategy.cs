using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
	[CreateAssetMenu(menuName = Constants.CoreCreateAssetMenuPrefix + "Unity Disable Strategy")]
	public class UnityDisableStrategy : ServiceBasedDespawnStrategy<UnityDisableService> { }
}