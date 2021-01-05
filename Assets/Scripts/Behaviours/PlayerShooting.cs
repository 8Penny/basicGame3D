using Behaviours.Base;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours {
    public class PlayerShooting : Shooting {
        private void OnFire(InputValue value) {
            Shoot(_transform.forward);
        }
    }
}