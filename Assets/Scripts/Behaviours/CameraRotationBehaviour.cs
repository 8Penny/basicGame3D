using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours {
    public class CameraRotationBehaviour : MonoBehaviour {
        [SerializeField] Transform _playerTransform;
        private float _rotationParameter;
        private float _halfScreenWidth;
        private const float MouseSensitivity = 10;


        private void Start() {
            Cursor.visible = false;
        }

        private void OnCameraMoved(InputValue value) {
            var xPosition = value.Get<float>();
            _rotationParameter = xPosition;
        }
        
        private void Update() {
            var mouseX = _rotationParameter * MouseSensitivity * Time.deltaTime;
            var yRotation = Mathf.Clamp(mouseX, -90f, 90f);
            _playerTransform.Rotate(0, yRotation, 0, Space.World);
        }
    }
}