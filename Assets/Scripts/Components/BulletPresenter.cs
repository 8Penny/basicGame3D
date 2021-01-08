using System;
using ScriptableObjects;
using UnityEngine;

namespace Components {
    public class BulletPresenter {
        public event Action changedEvent;
        public float lifetime => _lifetime;
        private float _lifetime;
        
        public float speed => _speed;
        private float _speed;
        
        public Vector3 direction => _direction;
        private Vector3 _direction;

        public bool isFromPlayer => _isFromPlayer;
        private bool _isFromPlayer;

        public BulletPresenter(BulletData data) {
            _lifetime = data.lifetime;
            _speed = data.speed;
            _direction = data.direction;
            _isFromPlayer = data.fromPlayer;
        }
    }
}