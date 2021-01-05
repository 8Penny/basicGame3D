using System;
using System.Collections.Generic;
using BehaviourInject;
using Behaviours;
using ScriptableObjects;
using UnityEngine;

namespace GlobalSystems {
    public class InstantiatingSystem : MonoBehaviour {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private GameObject _prismPrefab;
        [SerializeField] private GameObject _bulletPrefab;

        [SerializeField] private Transform _parentTransform;

        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private List<Transform> _cubeSpawnPoints;
        [SerializeField] private List<Transform> _prismSpawnPoints;

        private const float StartBulletYPosition = 0.4f;

        private Player _player;
        
        public void AddPlayer(Player p) {
            _player = p;
        }

        private void Awake() {
            InstantiatePlayer();
            InstantiateEnemies();
        }

        private void InstantiatePlayer() {
            var playerGO = InstantiateGO(_playerPrefab, _playerSpawnPoint.localPosition);
            _player.SetTransform(playerGO.transform);
        }

        private void InstantiateEnemies() {
            InstantiateFromList(_cubePrefab, _cubeSpawnPoints);
            InstantiateFromList(_prismPrefab, _prismSpawnPoints);
        }

        private void InstantiateFromList(GameObject prefab, List<Transform> spawnPoints) {
            for (var i = 0; i < spawnPoints.Count; i++) {
                InstantiateGO(prefab, spawnPoints[i].localPosition);
            }
        }

        public void InstantiateBullet(Vector3 direction, Vector3 position, BulletData bulletData) {
            position = new Vector3(position.x, StartBulletYPosition, position.z);
            var bulletGO = InstantiateGO(_bulletPrefab, position);

            var bMovement = bulletGO.GetComponent<BulletMovement>();
            bMovement.SetDirection(direction);
            bMovement.SetSpeed(bulletData.speed);

            bulletGO.GetComponent<SelfDestruction>().SetTimer(bulletData.lifetime);

            // PLAYERBULLET TAG
        }

        private GameObject InstantiateGO(GameObject prefab, Vector3 position) {
            var instance = Instantiate(prefab, _parentTransform);
            instance.transform.localPosition = position;
            return instance;
        }
    }
}