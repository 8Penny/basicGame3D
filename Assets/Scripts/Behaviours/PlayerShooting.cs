using Behaviours.Base;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours {
    public class PlayerShooting : Shooting {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private BulletData _bulletData;
        
        private void OnFire(InputValue value) {
            Shoot(_playerTransform.position, _playerTransform.forward, _bulletData);
        }
    }
}
