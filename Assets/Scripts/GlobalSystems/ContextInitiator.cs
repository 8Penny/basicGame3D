using BehaviourInject;
using UnityEngine;

namespace GlobalSystems {
    public class ContextInitiator : MonoBehaviour {
        [SerializeField] private UpdateSystem _updateSystem;
        [SerializeField] private InstantiatingSystem _instantiatingSystem;
        
        private Context _context;

        private void Awake()
        {
            _context = Context.Create()
                .RegisterDependency(_updateSystem)
                .RegisterDependency(_instantiatingSystem);
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