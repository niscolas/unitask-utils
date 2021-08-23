using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
	[CreateAssetMenu(menuName = Constants.ActionsCreateAssetMenuPath + "(string) => Log")]
	public class LogAtom : AtomAction<string>
	{
		public override void Do(string message)
		{
			Debug.Log(message);
		}
	}
}