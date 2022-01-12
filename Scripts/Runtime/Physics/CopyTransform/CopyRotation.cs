using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class CopyRotation : BaseCopyTransform
    {
        protected override void CopyTransform(Transform copyTarget)
        {
            transform.rotation = copyTarget.rotation;
        }
    }
}