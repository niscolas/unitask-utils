using System.Linq;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityAtoms.SceneMgmt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = SceneManagementConstants.CreateAssetMenuPrefix + "Scene Profile",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class SceneProfileSO : ScriptableObject
    {
        [SerializeField]
        private SceneFieldReference _scene;

        [SerializeField]
        private SceneFieldReference[] _additiveScenes;

        [AssetList]
        [SerializeField]
        private SceneTypeProfileSO _typeProfile;

        [SerializeField]
        private AtomCollection _additionalData;

        [Title("Events")]
        [SerializeField]
        private UnityEvent _loaded;

        public SceneField Scene => _scene.Value;

        public AtomCollection AdditionalData => _additionalData;

        public SceneTypeProfileSO TypeProfile => _typeProfile;

        public void Editor_Load()
        {
            SceneManagerUtility.LoadScene(Scene, LoadSceneMode.Single);

            if (_typeProfile)
            {
                _typeProfile.Editor_Load();
            }

            LoadAdditiveScenes();
        }

        public void OnLoaded()
        {
            if (_typeProfile)
            {
                _typeProfile.OnLoaded();
            }

            if (MasterLoader.ShouldLoadAdditiveScenes)
            {
                LoadAdditiveScenes();
            }

            _loaded?.Invoke();
        }

        public void LoadAdditiveScenes()
        {
            SceneManagerUtility.LoadScenes(
                _additiveScenes.Select(additiveScene => additiveScene.Value),
                LoadSceneMode.Additive);
        }
    }
}