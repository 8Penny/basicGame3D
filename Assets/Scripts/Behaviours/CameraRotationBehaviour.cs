using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours {
    public class CameraRotationBehaviour : MonoBehaviour {
        [SerializeField] Transform _playerTransform;
        private float _rotationParameter;
        private float _halfScreenWidth;
        private const float RotationSpeed = 150f;

        private void Awake() {
            _halfScreenWidth = Screen.width / 2.0f;
        }

        private void OnCameraMoved(InputValue value) {
            var xPosition = value.Get<float>();
            _rotationParameter = Mathf.Clamp((xPosition - _halfScreenWidth) / _halfScreenWidth, -1, 1);
            if (Math.Abs(_rotationParameter) < 0.05f) {
                _rotationParameter = 0;
            }
        }

        private void Update() {
            _playerTransform.Rotate(0, _rotationParameter * RotationSpeed * Time.deltaTime, 0, Space.World);
        }
    }
}