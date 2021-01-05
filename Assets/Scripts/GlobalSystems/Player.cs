using UnityEngine;

namespace GlobalSystems {
    public class Player {
        private Transform _transform;
        public Vector3 position => _transform.position;

        public void SetTransform(Transform t) {
            _transform = t;
        }
    }
}