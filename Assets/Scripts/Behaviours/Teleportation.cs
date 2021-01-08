using BehaviourInject;
using GlobalSystems;
using ScriptableObjects;
using UnityEngine;

namespace Behaviours {
    public class Teleportation : MonoBehaviour{
        
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private TeleportData _teleportData;
        
        private float _timeToNextTeleportation;

        private Player _player;

        [Inject]
        public void Init(Player p) {
            _player = p;
        }
        
        private void Awake() {
            _timeToNextTeleportation = Random.Range(0.5f, 3.0f) + _teleportData.periodTime;
        }
        
        private void Update() {
            if (_timeToNextTeleportation > 0) {
                _timeToNextTeleportation -= Time.deltaTime;
                return;
            }
            
            var positionX = Random.Range(7.0f, 35.0f);
            var positionY = Random.Range(7.0f, 25.0f);
            var signX = Random.value < 0.5f? 1 : -1;
            var signY = Random.value < 0.5f? 1 : -1;

            var position = _player.position + new Vector3(signX * positionX, 0, signY * positionY);
            _transform.localPosition = position;
            _timeToNextTeleportation = _teleportData.periodTime;
        }
    }
}