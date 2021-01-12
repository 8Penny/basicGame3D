using Components;
using UnityEngine;

namespace GlobalSystems {
    public class Player {
        private Transform _transform;
        private Health _health;
        
        public Vector3 position => _transform.position;
        public Health health => _health;

        public Player() {
            _health = new Health(100);
        }
        public void SetTransform(Transform t) {
            _transform = t;
        }
    }
}