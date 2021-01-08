using Behaviours.Base;
using GlobalSystems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours {
    public class PlayerMovement : Movement {

        private bool _isMovingForward;
        private bool _isMovingBack;
        private bool _isMovingLeft;
        private bool _isMovingRight;

                
        protected override void Awake() {
            SetSpeed(5.0f);
        }
        
        private void OnForward(InputValue value) {
            _isMovingForward = value.isPressed;
        }

        private void OnBack(InputValue value) {
            _isMovingBack = value.isPressed;
        }

        private void OnLeft(InputValue value) {
            _isMovingLeft = value.isPressed;
        }

        private void OnRight(InputValue value) {
            _isMovingRight = value.isPressed;
        }

        protected override void Update() {
            var direction = Vector3.zero;
            if (_isMovingForward) {
                direction += _transform.forward;
            }
            if (_isMovingBack) {
                direction -= _transform.forward;
            }
            if (_isMovingRight) {
                direction += _transform.right;
            }
            if (_isMovingLeft) {
                direction -= _transform.right;
            }
            
            SetDirection(direction);

            base.Update();
        }
    }
}