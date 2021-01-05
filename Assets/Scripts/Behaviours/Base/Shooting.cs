using BehaviourInject;
using GlobalSystems;
using ScriptableObjects;
using UnityEngine;

namespace Behaviours.Base {
    public abstract class Shooting : MonoBehaviour {
        [SerializeField] protected Transform _transform;
        [SerializeField] private BulletData _bulletData;
        private InstantiatingSystem _instantiatingSystem;

        [Inject]
        public void Init(InstantiatingSystem instantiatingSystem) {
            _instantiatingSystem = instantiatingSystem;
        }

        protected void Shoot(Vector3 direction) {
            _instantiatingSystem.InstantiateBullet(direction, _transform.position, _bulletData);
        }

        protected virtual void Awake() {
        }
    }
}