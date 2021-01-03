using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "TeleportData", menuName = "ScriptableObjects/TeleportData", order = 10)]
    public class TeleportData : ScriptableObject {
        public float periodTime;
    }
}
