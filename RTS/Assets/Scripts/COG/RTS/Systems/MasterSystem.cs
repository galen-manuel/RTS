using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COG.RTS
{
    public class MasterSystem : MonoBehaviour
    {
        private List<ISystem> _systems;

        public static MasterSystem Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _systems = new List<ISystem>();
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.sceneUnloaded += OnSceneUnloaded;
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

            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
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
            pSystem.InitSystem();
            pSystem.StartSystem();
        }

        public void UnregisterSystem(ISystem pSystem)
        {
            _systems.Remove(pSystem);
            pSystem.StopSystem();
            pSystem.ShutdownSystem();
        }

        public T GetSystem<T>() where T : MonoBehaviour, ISystem
        {
            foreach (ISystem system in _systems)
            {
                if (system is T typedSystem)
                {
                    return typedSystem;
                }
            }

            return null;
        }

        private void OnDestroy()
        {
            foreach (ISystem system in _systems)
            {
                system.ShutdownSystem();
            }
        }

        private static void OnSceneLoaded(Scene pScene, LoadSceneMode pLoadSceneMode)
        {
            GameObject[] rootGameObjects = pScene.GetRootGameObjects();
            foreach (GameObject rootGameObject in rootGameObjects)
            {
                ISystem system = rootGameObject.GetComponent<ISystem>();

                if (system != null)
                {
                    Instance.RegisterSystem(system);
                }
            }
        }

        private static void OnSceneUnloaded(Scene pScene)
        {
            GameObject[] rootGameObjects = pScene.GetRootGameObjects();
            foreach (GameObject rootGameObject in rootGameObjects)
            {
                ISystem system = rootGameObject.GetComponent<ISystem>();

                if (system != null)
                {
                    Instance.UnregisterSystem(system);
                }
            }
        }
    } 
}
