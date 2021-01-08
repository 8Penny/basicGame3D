using System;
using UnityEngine;

namespace Components {
    public class Health {
        private float _value;
        private float _maxValue;

        public float value => _value;

        public Health(float maxValue) {
            _maxValue = maxValue;
            _value = _maxValue;
        }

        public void SetHealth(float val) {
            _value = Mathf.Clamp(val, 0, _maxValue);
        }

        public void SetMaxHealth(float val) {
            _maxValue = Mathf.Clamp(val, 0, val);
        }

        public void TakeDamage(float val) {
            SetHealth(_value - val);
        }

        public void AddHealth(float val) {
            SetHealth(_value + val);
        }
    }
}