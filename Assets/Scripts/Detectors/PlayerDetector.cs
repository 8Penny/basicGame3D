using System;
using ScriptableObjects;
using UnityEngine;

namespace Detectors {
    public class PlayerDetector : MonoBehaviour {
        [SerializeField] private DetectData _detectData;
        [SerializeField] private SphereCollider _collider;
        public Action<bool> crossedByObject;

        private void Awake() {
            _collider.radius = _detectData.radius;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(EntityTags.Player)) {
                crossedByObject.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.gameObject.CompareTag(EntityTags.Player)) {
                crossedByObject.Invoke(false);
            }
        }
    }
}