using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "EnemyShootingData", menuName = "ScriptableObjects/EnemyShootingData", order = 9)]
    public class EnemyShootingData : ScriptableObject {
        public float periodTime;
    }
}