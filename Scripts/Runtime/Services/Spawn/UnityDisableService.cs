﻿using niscolas.UnityUtils.Extras;
using UnityEngine;
using UnityUtils;

namespace niscolas.UnityUtils
{
	public class UnityDisableService : IDespawnService
	{
		public async void Despawn<T>(T component, float delay = 0, bool immediate = false) where T : Component
		{
			if (component is Behaviour behaviour)
			{
				await Await.Seconds(delay, component.gameObject);
				behaviour.enabled = false;
			}
		}

		public async void Despawn(GameObject instance, float delay = 0, bool immediate = false)
		{
			await Await.Seconds(delay, instance);
			instance.SetActive(false);
		}
	}
}