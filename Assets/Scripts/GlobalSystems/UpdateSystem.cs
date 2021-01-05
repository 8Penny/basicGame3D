using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GlobalSystems {
    public class UpdateSystem : MonoBehaviour {
        private List<IUpdate> _updates = new List<IUpdate>();
        private int _elementCount;

        public void AddUpdateBehaviour(IUpdate u) {
            _updates.Add(u);
        }

        public void RemoveUpdateBehaviour(IUpdate u) {
            _updates.Remove(u);
        }

        private void Update() {
            for (var i = 0; i < _elementCount; i++) {
                _updates[i].Update();
            }
        }
    }
}