using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BestLostNFound
{
	[Serializable]
	public class SceneProfiles : IEnumerable<SceneProfile>
	{
		[SerializeField]
		private List<SceneProfile> _content;

		public bool TryGet(Scene scene, out SceneProfile profile)
		{
			profile = _content.FirstOrDefault(currentProfile => currentProfile.Scene.SceneName == scene.name);
			return profile;
		}

		public IEnumerator<SceneProfile> GetEnumerator()
		{
			return _content.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}