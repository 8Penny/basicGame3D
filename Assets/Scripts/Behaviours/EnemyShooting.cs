using System;
using BehaviourInject;
using Behaviours.Base;
using Detectors;
using GlobalSystems;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace Behaviours {
    public class EnemyShooting : Shooting {
        [SerializeField] private EnemyShootingData _enemyShootingData;
        [SerializeField] private ObjectDetector _objectDetector;

        private bool _isPlayerVisible;
        private float _timeToNextShot;

        private Player _player;

        [Inject]
        public void Init(Player p) {
            _player = p;
        }

        protected override void Awake() {
            base.Awake();
            _objectDetector.crossedByObject += DetectPlayer;
            _timeToNextShot += Random.Range(0.5f, 3.0f);
        }

        private void DetectPlayer(bool isVisible, Collider collider) {
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