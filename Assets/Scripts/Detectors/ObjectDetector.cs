using System;
using ScriptableObjects;
using Tags;
using UnityEngine;

namespace Detectors {
    public class ObjectDetector : MonoBehaviour {
        [SerializeField] private DetectData _detectData;
        [SerializeField] private CapsuleCollider _collider;
        [SerializeField] private EntityTag _tag;
        
        private string _objectTag;
        public Action<bool, Collider> crossedByObject;
        
        private void Awake() {
            _collider.radius = _detectData.radius;
            _objectTag = EntityTags.ToString(_tag);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(_objectTag)) {
                crossedByObject?.Invoke(true, other);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.gameObject.CompareTag(_objectTag)) {
                crossedByObject?.Invoke(false, other);
            }
        }
    }
}