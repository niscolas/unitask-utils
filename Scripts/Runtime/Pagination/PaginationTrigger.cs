using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public class PaginationTrigger : CachedMonoBehaviour
    {
        [Header("Events")]
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