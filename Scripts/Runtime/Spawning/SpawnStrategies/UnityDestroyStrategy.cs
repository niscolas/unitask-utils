using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	[CreateAssetMenu(menuName = Constants.CoreCreateAssetMenuPrefix + "Unity Destroy Strategy")]
	public class UnityDestroyStrategy : ServiceBasedDespawnStrategy<UnityDestroyService> { }
}