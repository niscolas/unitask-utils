using UnityEngine;

namespace BestLostNFound
{
	[CreateAssetMenu(menuName = SceneManagementConstants.BaseCreateSoAssetMenuPath + "Master Loader Profile")]
	public class MasterLoaderProfile : ScriptableObject
	{
		[SerializeField]
		private SceneProfiles _sceneProfiles;

		public SceneProfiles SceneProfiles => _sceneProfiles;
	}
}