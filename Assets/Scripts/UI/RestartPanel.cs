using System;
using BehaviourInject;
using GlobalSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class RestartPanel : MonoBehaviour {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Text _panelText;

        private RestartSystem _restartSystem;
        private const string GameOverText = "GameOver";
        private const string WinText = "You win!";

        [Inject]
        public void Init(RestartSystem restartSystem) {
            _restartSystem = restartSystem;
        }

        private void Awake() {
            _restartSystem.OnPlayerDeath += OnPlayerLose;
            _restartSystem.OnLastEnemyDeath += OnLastEnemyDeath;
        }


        private void OnPlayerLose() {
            _panelText.text = GameOverText;
            ShowRestartPanel();
        }

        private void OnLastEnemyDeath() {
            _panelText.text = WinText;
            ShowRestartPanel();
        }

        private void ShowRestartPanel() {
            _panel.SetActive(true);
        }
        
        private void HideRestartPanel() {
            _panel.SetActive(false);
        }

        private void OnDestroy() {
            _restartSystem.OnPlayerDeath -= OnPlayerLose;
            _restartSystem.OnLastEnemyDeath -= OnLastEnemyDeath;
        }

        public void OnRestartButtonClick() {
            HideRestartPanel();
            _restartSystem.Restart();
        }
    }
}