using niscolas.UnityUtils.Core;
using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(string) => Log")]
    public class LogStringAtomAction : AtomAction<string>
    {
        [SerializeField]
        private LogType _logType = LogType.Log;
        
        public override void Do(string message)
        {
            TheBugger.Log(message, _logType);
        }
    }
}