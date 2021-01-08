using BehaviourInject;
using GlobalSystems;
using ScriptableObjects;
using UnityEngine;

namespace Behaviours.Base {
    public abstract class Shooting : MonoBehaviour {
        [SerializeField] protected Transform _transform;
        [SerializeField] protected BulletData _bulletData;
        
        private InstantiatingSystem _instantiatingSystem;

        [Inject]
        public void Init(InstantiatingSystem instantiatingSystem) {
            _instantiatingSystem = instantiatingSystem;
        }

        protected virtual void Awake() {
            _bulletData = Instantiate(_bulletData);
        }

        protected void Shoot(Vector3 direction) {
            var currentBData = Instantiate(_bulletData);
            currentBData.direction = direction;
            currentBData.startPosition = _transform.position;
            _instantiatingSystem.InstantiateBullet(currentBData);
        }

    }
}