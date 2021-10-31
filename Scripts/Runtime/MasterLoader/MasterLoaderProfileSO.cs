using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = SceneManagementConstants.CreateAssetMenuPrefix + "Master Loader Profile",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class MasterLoaderProfileSO : ScriptableObject
    {
        [SerializeField]
        private SceneProfiles _sceneProfiles;

        public SceneProfiles SceneProfiles => _sceneProfiles;
    }
}