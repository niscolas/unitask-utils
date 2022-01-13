using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Bounds")]
    public class BoundsMB : CachedMonoBehaviour
    {
        [SerializeField]
        private Transform _center;

        [SerializeField]
        private Vector3Reference _size;

        [Header("Visualization")]
        [ColorUsage(true, true)]
        [SerializeField]
        private Color _gizmosColor = Color.blue;

        [SerializeField]
        private bool _drawAlways;

        public Transform Center
        {
            get => _center;
            set => _center = value;
        }

        public Vector3Reference Size => _size;

        public Bounds Bounds { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            UpdateBounds();
        }

        private void OnDrawGizmos()
        {
            if (!_drawAlways)
            {
                return;
            }

            Draw();
        }

        private void OnDrawGizmosSelected()
        {
            if (_drawAlways)
            {
                return;
            }

            Draw();
        }

        public void UpdateBounds()
        {
            if (!_center)
            {
                return;
            }

            Vector3 centerPosition = _center.position;
            Vector3 sizeValue = _size.Value;
            Bounds = new Bounds(centerPosition, sizeValue);
        }

        private void Draw()
        {
            if (!_center)
            {
                _center = transform;
            }

            Vector3 centerPosition = _center.position;
            Vector3 sizeValue = _size.Value;

            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireCube(centerPosition, sizeValue);
        }
    }
}