using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tags {
    public static class EntityTags {
        public static string ToString(EntityTag tag) {
            switch (tag) {
               case EntityTag.Player:
                   return "Player";
               case EntityTag.Enemy:
                   return "Enemy";
               case EntityTag.Bullet:
                   return "Bullet";
               default:
                   return null;
            }
        }
    }
    public enum EntityTag { 
        Player,
        Enemy,
        Bullet
    }
}