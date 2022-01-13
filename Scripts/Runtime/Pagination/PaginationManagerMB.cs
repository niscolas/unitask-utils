using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Pagination Manager")]
    public class PaginationManagerMB : CachedMB
    {
        [SerializeField]
        private PaginationTriggerMB _leftPaginationTrigger;

        [SerializeField]
        private PaginationTriggerMB _rightPaginationTrigger;

        [SerializeField]
        private IntReference _currentPageIndex;

        [SerializeField]
        private IntReference _maxPageIndex;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<int> _onPageLoaded;

        private void OnEnable()
        {
            CheckPaginationAllowance(0);
        }

        public void PassPages(int pageDelta)
        {
            if (pageDelta == 0)
            {
                return;
            }

            int targetPageIndex = _currentPageIndex.Value + pageDelta;

            if (targetPageIndex < 0 || targetPageIndex > _maxPageIndex.Value)
            {
                return;
            }

            if (pageDelta < 0)
            {
                _leftPaginationTrigger.OnPaginationTriggered();
            }
            else
            {
                _rightPaginationTrigger.OnPaginationTriggered();
            }

            CheckPaginationAllowance(targetPageIndex);

            _currentPageIndex.Value = targetPageIndex;

            _onPageLoaded?.Invoke(_currentPageIndex.Value);
        }

        private void CheckPaginationAllowance(int targetPageIndex)
        {
            if (targetPageIndex == 0)
            {
                _leftPaginationTrigger.OnNoPaginationAllowed();
            }
            else
            {
                _leftPaginationTrigger.OnPaginationReallowed();
            }

            if (targetPageIndex == _maxPageIndex.Value)
            {
                _rightPaginationTrigger.OnNoPaginationAllowed();
            }
            else
            {
                _rightPaginationTrigger.OnPaginationReallowed();
            }
        }

        public void PassToNextPage()
        {
            PassPages(+1);
        }

        public void PassToPreviousPage()
        {
            PassPages(-1);
        }
    }
}