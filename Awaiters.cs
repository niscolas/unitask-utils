using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace niscolas.UniTaskUtils
{
	public static class Awaiters
	{
		private static GameObject _gameObjectRef;

		private static GameObject GameObjectRef
		{
			get
			{
				if (!_gameObjectRef)
				{
					_gameObjectRef = new GameObject("UniTaskUtils");
					Object.DontDestroyOnLoad(_gameObjectRef);
				}

				return _gameObjectRef;
			}
		}

		public static UniTask Seconds(float seconds)
		{
			return Seconds(seconds, GameObjectRef);
		}

		public static UniTask Seconds(float seconds, GameObject gameObject)
		{
			return UniTask.Delay(TimeSpan.FromSeconds(seconds),
				cancellationToken: gameObject.GetCancellationTokenOnDestroy());
		}
	}
}