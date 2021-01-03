using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "PlayerDetectData", menuName = "ScriptableObjects/PlayerDetectData", order = 8)]
    public class PlayerDetectData: ScriptableObject {
        public float radius;
    }
}