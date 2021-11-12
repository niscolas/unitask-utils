using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
	[CreateAssetMenu(
		menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(Animator) => Set Bool")]
	public class SetAnimatorBoolAtomAction : BaseSetAnimatorParamAtomAction<bool>
	{
		public override void Do(Animator animator)
		{
			animator.SetBool(paramName.Value, value);
		}
	}
}