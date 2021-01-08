using BehaviourInject;
using Components;
using GlobalSystems;
using UnityEngine;

namespace UI {
    public class HealthBar : MonoBehaviour {
        [SerializeField] private RectTransform _healthBar;

        private Player _player;

        private Health _playerHealth;

        [Inject]
        public void Init(Player p) {
            _player = p;
        }

        private void Awake() {
            _playerHealth = _player.health;
            OnHealthChanged();
        }

        private void OnEnable() {
            _playerHealth.OnChanged += OnHealthChanged;
        }

        private void OnHealthChanged() {
            var percentage = _playerHealth.value / _playerHealth.maxValue;
            _healthBar.localScale = new Vector3(percentage, 1, 1);
        }

        private void OnDisable() {
            _playerHealth.OnChanged -= OnHealthChanged;
        }
    }
}