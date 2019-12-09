using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS.Systems
{
    public class MasterSystem : MonoBehaviour
    {
        private List<ISystem> _systems;

        public MasterSystem Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _systems = new List<ISystem>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            foreach (ISystem system in _systems)
            {
                system.UpdateSystem(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            foreach (ISystem system in _systems)
            {
                system.LateUpdateSystem(Time.deltaTime);
            }
        }

        public void RegisterSystem(ISystem pSystem)
        {
            _systems.Add(pSystem);
        }
    } 
}
