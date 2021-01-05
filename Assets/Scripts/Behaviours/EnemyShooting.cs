using System;
using BehaviourInject;
using Behaviours.Base;
using Detectors;
using GlobalSystems;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements;

namespace Behaviours {
    public class EnemyShooting : Shooting {
        [SerializeField] private EnemyShootingData _enemyShootingData;
        [SerializeField] private PlayerDetector _playerDetector;

        private bool _isPlayerVisible;
        private float _timeToNextShot;

        private Player _player;

        [Inject]
        public void Init(Player p) {
            _player = p;
        }

        protected override void Awake() {
            _playerDetector.crossedByObject += DetectPlayer;
        }

        private void DetectPlayer(bool isVisible) {
            _isPlayerVisible = isVisible;
        }

        private void Update() {
            if (_timeToNextShot > 0) {
                _timeToNextShot -= Time.deltaTime;
                return;
            }

            if (!_isPlayerVisible) {
                return;
            }
            
            Shoot(_player.position - _transform.localPosition);
            _timeToNextShot = _enemyShootingData.periodTime;
        }
    }
}