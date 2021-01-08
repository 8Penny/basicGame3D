using System;
using Behaviours;
using UnityEngine;

namespace Components {
    public class BulletView : MonoBehaviour {
        [SerializeField] private BulletMovement _bulletMovement;
        [SerializeField] private SelfDestruction _selfDestruction;

        private BulletPresenter _presenter;

        public bool isFromPlayer => _presenter.isFromPlayer;

        public void SetPresenter(BulletPresenter p) {
            _presenter = p;
            OnChanged();
        }

        private void Start() {
            _presenter.changedEvent += OnChanged;
        }

        private void OnDestroy() {
            _presenter.changedEvent -= OnChanged;
        }

        private void OnChanged() {
            _selfDestruction.SetTimer(_presenter.lifetime);
            _bulletMovement.SetDirection(_presenter.direction);
            _bulletMovement.SetSpeed(_presenter.speed);
        }
    }
}