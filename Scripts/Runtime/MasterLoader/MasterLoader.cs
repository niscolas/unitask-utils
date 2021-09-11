using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO move to the correct namespace
namespace BestLostNFound
{
    public static class MasterLoader
    {
        public static bool ShouldLoadAdditiveScenes =>
            !Application.isEditor ||
            Application.isEditor && _enteredPlayMode;

        private const string ProfilePath = nameof(MasterLoaderProfile);

        private static MasterLoaderProfile _profile;
        private static bool _enteredPlayMode;

#if UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            _enteredPlayMode = false;

            EditorApplication.playModeStateChanged -= PlayModeStateChanged;
            EditorApplication.playModeStateChanged += PlayModeStateChanged;
        }

        private static void PlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (playModeStateChange != PlayModeStateChange.EnteredPlayMode)
            {
                return;
            }

            _enteredPlayMode = true;
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            if (!_profile)
            {
                _profile = FindProfile();
            }

            SceneManager.sceneLoaded += SceneManager_OnSceneLoaded;
        }

        public static MasterLoaderProfile FindProfile()
        {
            return Resources.Load<MasterLoaderProfile>(ProfilePath);
        }

        private static void SceneManager_OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            OnSceneLoaded(scene);
        }

        private static void OnSceneLoaded(Scene scene)
        {
            if (!_profile.SceneProfiles.TryGet(scene, out SceneProfile sceneProfile))
            {
                return;
            }

            sceneProfile.OnLoaded();
        }
    }
}