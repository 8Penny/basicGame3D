using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 7)]
    public class BulletData : ScriptableObject {
        public float speed;
        public float lifetime;
        public bool fromPlayer;

        [HideInInspector]
        public Vector3 direction;

        [HideInInspector]
        public Vector3 startPosition;
    }
}