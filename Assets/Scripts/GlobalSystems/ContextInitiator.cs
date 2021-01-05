using BehaviourInject;
using UnityEngine;

namespace GlobalSystems {
    public class ContextInitiator : MonoBehaviour {
        [SerializeField] private UpdateSystem _updateSystem;
        [SerializeField] private InstantiatingSystem _instantiatingSystem;

        private Context _context;

        private void Awake() {
            var player = new Player();
            _instantiatingSystem.AddPlayer(player);
            _context = Context.Create()
                .RegisterDependency(_updateSystem)
                .RegisterDependency(_instantiatingSystem)
                .RegisterDependency(player);
        }
        
        private void OnDestroy()
        {
            _context.Destroy();
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}