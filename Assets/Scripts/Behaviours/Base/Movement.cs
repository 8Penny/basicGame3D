using System;
using UnityEngine;

namespace Behaviours.Base {
    public abstract class Movement : MonoBehaviour {
        [SerializeField] protected Transform _transform;
        private Vector3 _direction;
        private float _movementSpeed = 1.0f;

        public void SetSpeed(float speed) {
            _movementSpeed = speed;
        }
        public void SetDirection(Vector3 dir) {
            _direction = dir.normalized;
        }
        protected virtual void Update() {
            _transform.position += _direction * (Time.deltaTime * _movementSpeed);
        }

        protected virtual void Awake() {
        }
    }
}
