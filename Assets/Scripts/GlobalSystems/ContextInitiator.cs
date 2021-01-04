using BehaviourInject;
using UnityEngine;

namespace GlobalSystems {
    public class ContextInitiator : MonoBehaviour {
        private Context _context;

        // private void Awake()
        // {
        //     _context = Context.Create()
        //         .RegisterDependency(new ContextInitiator());
        //
        // }
        //
        // private void OnDestroy()
        // {
        //     _context.Destroy();
        // }
        //
        // public void Destroy()
        // {
        //     Destroy(gameObject);
        // }
    }
}