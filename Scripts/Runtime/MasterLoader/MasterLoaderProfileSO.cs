using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = SceneManagementConstants.CreateAssetMenuPrefix + "Master Loader Profile",
        order = Constants.CreateAssetMenuOrder)]
    public class MasterLoaderProfileSO : ScriptableObject
    {
        [SerializeField]
        private SceneProfiles _sceneProfiles;

        public SceneProfiles SceneProfiles => _sceneProfiles;
    }
}
