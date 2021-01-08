using Components;
using Detectors;
using System;
using System.Runtime.InteropServices;
using BehaviourInject;
using GlobalSystems;
using UnityEngine;

namespace Behaviours {
    public class Damage : MonoBehaviour {
        [SerializeField] private ObjectDetector _bulletDetector;
        [SerializeField] private bool _isPlayer;

        private RestartSystem _restartSystem;
        private Health _health;

        public event Action<bool> OnDeath;

        [Inject]
        public void Init(RestartSystem r) {
            _restartSystem = r;
        }

        public void SetHealth(Health h) {
            _health = h;
        }

        private void Awake() {
            _bulletDetector.crossedByObject += OnBulletDetected;
            OnDeath += _restartSystem.OnActorDeath;
        }

        private void OnBulletDetected(bool isEntering, Collider bullet) {
            var bulletView = bullet.GetComponent<BulletView>();

            if (bulletView.isFromPlayer ^ _isPlayer) {
                _health.TakeDamage(1);
                Destroy(bullet.gameObject);
            }

            if (_health.value != 0) {
                return;
            }
            
            OnDeath?.Invoke(_isPlayer);
            
            if (!_isPlayer) {
                Destroy(gameObject);
            }
        }

        private void OnDestroy() {
            OnDeath -= _restartSystem.OnActorDeath;
        }
    }
}