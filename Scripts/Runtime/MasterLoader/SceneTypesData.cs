// using System;
// using System.Collections.Generic;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace BestLostNFound
// {
// 	[Serializable]
// 	public class SceneTypesData
// 	{
// 		[DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)]
// 		[HideReferenceObjectPicker]
// 		[SerializeField]
// 		private Dictionary<SceneType, SceneTypeProfile> _content = new Dictionary<SceneType, SceneTypeProfile>();
//
// 		public bool TryGet(SceneType type, out SceneTypeProfile profile)
// 		{
// 			return _content.TryGetValue(type, out profile);
// 		}
// 	}
// }