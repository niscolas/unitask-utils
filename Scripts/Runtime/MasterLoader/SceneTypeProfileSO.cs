using System.Linq;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.SceneMgmt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace niscolas.UnityUtils.Extras
{
    [CreateAssetMenu(
        menuName = SceneManagementConstants.CreateAssetMenuPrefix + "Scene Type Profile",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class SceneTypeProfileSO : ScriptableObject
    {
        [SerializeField]
        private SceneFieldReference[] _additiveScenes;

        [HideReferenceObjectPicker]
        [SerializeField]
        private UnityEvent _loaded;

        public void Editor_Load()
        {
            LoadAdditiveScenes();
        }

        public void OnLoaded()
        {
            if (MasterLoader.ShouldLoadAdditiveScenes)
            {
                LoadAdditiveScenes();
            }

            _loaded?.Invoke();
        }

        private void LoadAdditiveScenes()
        {
            SceneManagerUtility.LoadScenes
            (
                _additiveScenes.Select(additiveScene => additiveScene.Value),
                LoadSceneMode.Additive
            );
        }
    }
}