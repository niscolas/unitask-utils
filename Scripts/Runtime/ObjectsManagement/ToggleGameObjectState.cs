using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
	[CreateAssetMenu(
		menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(GameObject) => Toggle Active State")]
	public class ToggleGameObjectState : AtomAction<GameObject>
	{
		public override void Do(GameObject entry)
		{
			if (!entry)
			{
				return;
			}

			entry.SetActive(!entry.activeSelf);
		}
	}
}