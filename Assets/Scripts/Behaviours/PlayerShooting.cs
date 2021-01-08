using Behaviours.Base;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours {
    public class PlayerShooting : Shooting {

        protected override void Awake() {
            base.Awake();
            _bulletData.fromPlayer = true;
        }
        private void OnFire(InputValue value) {
            Shoot(_transform.forward);
        }
    }
}