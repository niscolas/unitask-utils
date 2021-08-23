using System.Linq;
using Sirenix.OdinInspector;
using UnityAtoms.SceneMgmt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BestLostNFound
{
    [CreateAssetMenu(menuName = SceneManagementConstants.BaseCreateSoAssetMenuPath + "Scene Type Profile")]
    public class SceneTypeProfile : ScriptableObject
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