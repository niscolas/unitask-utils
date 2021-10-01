using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace niscolas.UnityUtils.Extras
{
    public static class MasterLoader
    {
        public static event Action<SceneProfileSO> BeforeSceneProfileLoaded;
        public static event Action<SceneProfileSO> AfterSceneProfileLoaded;

        public static SceneProfileSO CurrentSceneProfile => _currentSceneProfile;
        
        public static bool ShouldLoadAdditiveScenes =>
            !Application.isEditor ||
            Application.isEditor && _enteredPlayMode;

        private const string ProfilePath = "MasterLoaderProfile";

        private static MasterLoaderProfileSO _profile;
        private static SceneProfileSO _currentSceneProfile;
        private static bool _enteredPlayMode;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
#if UNITY_EDITOR
            _enteredPlayMode = false;

            EditorApplication.playModeStateChanged += PlayModeStateChanged;
#endif
            
            if (!TryFindProfile(out _profile))
            {
                return;
            }

            SceneManager.sceneLoaded += SceneManager_OnSceneLoaded;
        }

#if UNITY_EDITOR
        private static void PlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (playModeStateChange != PlayModeStateChange.EnteredPlayMode)
            {
                return;
            }

            _enteredPlayMode = true;
        }
#endif

        public static bool TryFindProfile(out MasterLoaderProfileSO profile)
        {
            profile = _profile;
            if (_profile)
            {
                return true;
            }

            profile = Resources.Load<MasterLoaderProfileSO>(ProfilePath);
            return profile;
        }

        private static void SceneManager_OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (loadSceneMode == LoadSceneMode.Additive)
            {
                return;
            }
            
            OnSceneLoaded(scene);
        }

        private static void OnSceneLoaded(Scene scene)
        {
            if (!_profile ||
                !_profile.SceneProfiles.TryGet(scene, out _currentSceneProfile))
            {
                return;
            }

            BeforeSceneProfileLoaded?.Invoke(_currentSceneProfile);
            _currentSceneProfile.OnLoaded();
            AfterSceneProfileLoaded?.Invoke(_currentSceneProfile);
        }
    }
}