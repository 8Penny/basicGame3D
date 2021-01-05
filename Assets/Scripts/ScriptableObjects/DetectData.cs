using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "DetectData", menuName = "ScriptableObjects/DetectData", order = 8)]
    public class DetectData: ScriptableObject {
        public float radius;
    }
}