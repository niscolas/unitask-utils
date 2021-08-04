using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
	[CreateAssetMenu(
		menuName = Constants.ActionsCreateAssetMenuPath + "(Animator) => Set Bool")]
	public class SetAnimatorBool : BaseSetAnimatorParam<bool>
	{
		public override void Do(Animator animator)
		{
			animator.SetBool(paramName.Value, value);
		}
	}
}