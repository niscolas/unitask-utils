using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Copy Rotation")]
    public class CopyRotationMB : BaseCopyTransformMB
    {
        protected override void CopyTransform(Transform copyTarget)
        {
            transform.rotation = copyTarget.rotation;
        }
    }
}