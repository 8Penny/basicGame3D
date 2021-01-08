using System;
using Tags;
using UnityEngine;

namespace GlobalSystems {
    public class RestartSystem : MonoBehaviour {
        public event Action OnPlayerDeath;
        public event Action OnLastEnemyDeath;
        public event Action OnRestart;

        private string _enemyTag;

        private void Awake() {
            _enemyTag = EntityTags.ToString(EntityTag.Enemy);
        }

        public void OnActorDeath(bool wasPlayer) {
            if (wasPlayer) {
                OnPlayerDeath?.Invoke();
                PauseGame();
                return;
            }

            if (!IsAnyEnemyAlive()) {
                OnLastEnemyDeath?.Invoke();
                PauseGame();
            }
        }

        private bool IsAnyEnemyAlive() {
            var gameObjects = GameObject.FindGameObjectsWithTag(_enemyTag);
            return gameObjects.Length > 1;
        }

        public void Restart() {
            DestroyEntitiesWithTag(EntityTag.Bullet);
            DestroyEntitiesWithTag(EntityTag.Enemy);
            OnRestart?.Invoke();

            ResumeGame();
        }

        private void DestroyEntitiesWithTag(EntityTag tag) {
            var gameObjects = GameObject.FindGameObjectsWithTag(EntityTags.ToString(tag));
            for (var i = 0; i < gameObjects.Length; i++) {
                Destroy(gameObjects[i]);
            }
        }

        private void PauseGame() {
            Time.timeScale = 0;
            Cursor.visible = true;
        }

        private void ResumeGame() {
            Time.timeScale = 1;
            Cursor.visible = false;
        }
    }
}