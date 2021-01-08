using Components;
using Detectors;
using Tags;
using UnityEngine;

namespace Behaviours {
    public class Damage : MonoBehaviour {
        [SerializeField] private ObjectDetector _bulletDetector;
        [SerializeField] private bool _isPlayer;

        private Health _health;

        public void SetHealth(Health h) {
            _health = h;
        }

        private void Awake() {
            _bulletDetector.crossedByObject += OnBulletDetected;
        }

        private void OnBulletDetected(bool isEntering, Collider bullet) {
            var bulletView = bullet.GetComponent<BulletView>();

            if (bulletView.isFromPlayer ^ _isPlayer) {
                _health.TakeDamage(1);
                Destroy(bullet.gameObject);
            }

            if (!_isPlayer && _health.value == 0) {
                Destroy(gameObject);
            }
        }
    }
}