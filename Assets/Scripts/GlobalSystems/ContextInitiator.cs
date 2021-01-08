using BehaviourInject;
using UnityEngine;

namespace GlobalSystems {
    public class ContextInitiator : MonoBehaviour {
        [SerializeField]
        private InstantiatingSystem _instantiatingSystem;
        [SerializeField]
        private RestartSystem _restartSystem;

        private Context _context;

        private void Awake() {
            var player = new Player();
            _instantiatingSystem.Init(player, _restartSystem);
            _context = Context.Create()
                .RegisterDependency(_instantiatingSystem)
                .RegisterDependency(_restartSystem)
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