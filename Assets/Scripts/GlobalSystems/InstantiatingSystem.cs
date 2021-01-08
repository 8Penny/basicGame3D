using System;
using System.Collections.Generic;
using BehaviourInject;
using Behaviours;
using Components;
using ScriptableObjects;
using UnityEngine;

namespace GlobalSystems {
    public class InstantiatingSystem : MonoBehaviour {
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private GameObject _prismPrefab;
        [SerializeField] private GameObject _bulletPrefab;

        [SerializeField] private GameObject _playerGO;

        [SerializeField] private Transform _parentTransform;

        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private List<Transform> _cubeSpawnPoints;
        [SerializeField] private List<Transform> _prismSpawnPoints;

        private const float StartBulletYPosition = 0.4f;

        private Player _player;
        private RestartSystem _restartSystem;
        
        public void Init(Player player, RestartSystem restartSystem) {
            _player = player;
            _restartSystem = restartSystem;
        }

        private void Awake() {
            InstantiateLocationActors();
            _restartSystem.OnRestart += InstantiateLocationActors;
        }

        private void InstantiateLocationActors() {
            InstantiatePlayer();
            InstantiateEnemies();
        }

        private void InstantiatePlayer() {
            _playerGO.transform.localPosition = _playerSpawnPoint.localPosition;
            _player.SetTransform(_playerGO.transform);
            _player.health.Reset();
            AddHealthCmp(_playerGO, _player.health);
        }

        private void InstantiateEnemies() {
            InstantiateEnemiesFromList(_cubePrefab, _cubeSpawnPoints);
            InstantiateEnemiesFromList(_prismPrefab, _prismSpawnPoints);
        }

        private void InstantiateEnemiesFromList(GameObject prefab, List<Transform> spawnPoints) {
            for (var i = 0; i < spawnPoints.Count; i++) {
                var go = InstantiateGO(prefab, spawnPoints[i].localPosition);
                var health = new Health(1);
                AddHealthCmp(go, health);
            }
        }

        public void InstantiateBullet(BulletData bulletData) {
            var position = new Vector3(bulletData.startPosition.x, StartBulletYPosition, bulletData.startPosition.z);
            var bulletGO = InstantiateGO(_bulletPrefab, position);

            var bulletView = bulletGO.GetComponent<BulletView>();
            var bulletPresenter = new BulletPresenter(bulletData);

            bulletView.SetPresenter(bulletPresenter);
        }

        private GameObject InstantiateGO(GameObject prefab, Vector3 position) {
            var instance = Instantiate(prefab, _parentTransform);
            instance.transform.localPosition = position;
            return instance;
        }

        private void AddHealthCmp(GameObject go, Health health) {
            var damageCmp = go.GetComponent<Damage>();
            damageCmp.SetHealth(health);
        }

        private void OnDestroy() {
            _restartSystem.OnRestart -= InstantiateLocationActors;
        }
    }
}