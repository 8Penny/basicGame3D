using BehaviourInject;
using GlobalSystems;
using ScriptableObjects;
using UnityEngine;

namespace Behaviours.Base {
    public abstract class Shooting : MonoBehaviour {
        private InstantiatingSystem _instantiatingSystem;

        [Inject]
        public void Init(InstantiatingSystem instantiatingSystem) {
            _instantiatingSystem = instantiatingSystem;
        }

        protected void Shoot(Vector3 position, Vector3 direction, BulletData data) {
            _instantiatingSystem.InstantiateBullet(position, direction, data);
        }
    }
}