﻿using System.Linq;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
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
        private StringReference _label;

        [SerializeField]
        private SceneFieldReference[] _additiveScenes;

        [HideReferenceObjectPicker]
        [SerializeField]
        private UnityEvent _loaded;

        public string Label
        {
            get
            {
                if (string.IsNullOrEmpty(_label.Value))
                {
                    return name;
                }
                else
                {
                    return _label.Value;
                }
            }
        }

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