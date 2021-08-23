using System.Collections.Generic;
using UnityAtoms.SceneMgmt;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BestLostNFound
{
    public static class SceneManagerUtility
    {
        private static readonly Dictionary<LoadSceneMode, OpenSceneMode> LoadSceneToOpenSceneModeMapping =
            new Dictionary<LoadSceneMode, OpenSceneMode>
            {
                {LoadSceneMode.Single, OpenSceneMode.Single},
                {LoadSceneMode.Additive, OpenSceneMode.Additive}
            };

        public static void LoadScenes(IEnumerable<SceneField> scenes, LoadSceneMode loadSceneMode)
        {
            foreach (SceneField scene in scenes)
            {
                LoadScene(scene, loadSceneMode);
            }
        }

        public static void LoadScene(SceneField scene, LoadSceneMode loadSceneMode)
        {
            if (!Application.isPlaying)
            {
                EditorSceneManager.OpenScene(scene.ScenePath, LoadSceneToOpenSceneModeMapping[loadSceneMode]);
            }
            else
            {
                SceneManager.LoadScene(scene.SceneName, loadSceneMode);
            }
        }
    }
}