using Cysharp.Threading.Tasks;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public interface IWaypointWalker
    {
        GameObject GameObject { get; }
        
        void WalkToInstant(Vector3 targetPosition);
        
        UniTask WalkTo(Vector3 targetPosition);
    }
}