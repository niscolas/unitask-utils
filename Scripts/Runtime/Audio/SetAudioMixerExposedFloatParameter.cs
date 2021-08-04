using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Audio;

namespace niscolas.UnityUtils.UnityAtoms
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath + "(float) => Set Exposed Audio Mixer Parameter")]
	public class SetAudioMixerExposedFloatParameter : FloatAction
	{
		[SerializeField]
		private StringReference exposedParamNameRef;

		[SerializeField]
		private AudioMixer audioMixer;

		public override void Do(float value)
		{
			audioMixer.SetFloat(exposedParamNameRef.Value, value);
		}
	}
}