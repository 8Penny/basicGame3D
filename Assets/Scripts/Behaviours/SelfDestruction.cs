using UnityEngine;

namespace Behaviours {
    public class SelfDestruction : MonoBehaviour {
        private float _timeLeft;

        public void SetTimer(float time) {
            _timeLeft = time;
        }
        private void Update() {
            if (_timeLeft < 0) {
                Destroy(gameObject);
            }
            _timeLeft -= Time.deltaTime;
        }
    }
}
