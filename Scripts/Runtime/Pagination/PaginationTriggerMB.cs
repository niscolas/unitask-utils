using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Pagination Trigger")]
    public class PaginationTriggerMB : CachedMonoBehaviour
    {
        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onPaginationReallowed;

        [SerializeField]
        private UnityEvent _onNoPaginationAllowed;

        [SerializeField]
        private UnityEvent _onPaginationTriggered;

        public void OnPaginationReallowed()
        {
            _onPaginationReallowed?.Invoke();
        }

        public void OnNoPaginationAllowed()
        {
            _onNoPaginationAllowed?.Invoke();
        }

        public void OnPaginationTriggered()
        {
            _onPaginationTriggered?.Invoke();
        }
    }
}