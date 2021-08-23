using System.Linq;
using Sirenix.OdinInspector;
using UnityAtoms.SceneMgmt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BestLostNFound
{
    [CreateAssetMenu(menuName = SceneManagementConstants.BaseCreateSoAssetMenuPath + "Scene Profile")]
    public class SceneProfile : ScriptableObject
    {
        [SerializeField] 
         private SceneFieldReference _scene; 

        [SerializeField]
        private SceneFieldReference[] _additiveScenes;

        [AssetList]
        [SerializeField]
        private SceneTypeProfile _typeProfile;

        [Title("Events")]
        [SerializeField]
        private UnityEvent _loaded;

        public SceneField Scene => _scene.Value;

        public SceneTypeProfile TypeProfile => _typeProfile;


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
