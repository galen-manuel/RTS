using System;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS 
{
    public class CogBehaviourSystem : MonoBehaviour, ISystem
    {
        private List<CogBehaviour> _cogBehaviours;
        private List<Action<float>> _cogBehaviourUpdateFunctions;
        private List<Action<float>> _cogBehaviourLateUpdateFunctions;
        private bool _paused;

        public void InitSystem(MasterSystem masterSystem)
        {
            _cogBehaviours = new List<CogBehaviour>();
            _cogBehaviourUpdateFunctions = new List<Action<float>>();
            _cogBehaviourLateUpdateFunctions = new List<Action<float>>();
        }

        public void StartSystem()
        {
            _paused = false;
            foreach (CogBehaviour cogBehaviour in _cogBehaviours)
            {
                cogBehaviour.Init();
            }
        }

        public void UpdateSystem(float pDeltaTime)
        {
            if (_paused)
            {
                return;
            }
            
            foreach (Action<float> cogBehaviourUpdateFunction in _cogBehaviourUpdateFunctions)
            {
                cogBehaviourUpdateFunction(pDeltaTime);
            }
        }

        public void LateUpdateSystem(float pDeltaTime)
        {
            if (_paused)
            {
                return;
            }

            foreach (Action<float> cogBehaviourLateUpdateFunction in _cogBehaviourLateUpdateFunctions)
            {
                cogBehaviourLateUpdateFunction(pDeltaTime);
            }
        }

        public void PauseSystem()
        {
            _paused = true;

            foreach (CogBehaviour cogBehaviour in _cogBehaviours)
            {
                cogBehaviour.Pause();
            }
        }

        public void ResumeSystem()
        {
            _paused = false;

            foreach (CogBehaviour cogBehaviour in _cogBehaviours)
            {
                cogBehaviour.Resume();
            }
        }

        public void StopSystem()
        {
            foreach (CogBehaviour cogBehaviour in _cogBehaviours)
            {
                cogBehaviour.Stop();
            }
        }

        public void ShutdownSystem()
        {
            foreach (CogBehaviour cogBehaviour in _cogBehaviours)
            {
                cogBehaviour.CleanUp();
            }
        }

        /// <summary>
        /// Creates a new GameObject and adds a new behaviour of the desired type.
        /// </summary>
        /// <param name="pGameObjectName">The name of the newly created GameObject. Defaults to <code>nameof(T)</code></param>
        /// <typeparam name="T">The CogBehaviour type</typeparam>
        /// <returns>The newly created GameObject</returns>
        public GameObject CreateBehaviour<T>(string pGameObjectName = nameof(T)) where T : CogBehaviour
        {
            GameObject newGameObject = new GameObject(pGameObjectName);
            AddBehaviour<T>(newGameObject);

            return newGameObject;
        }

        /// <summary>
        /// Add a new behaviour to the provided GameObject
        /// </summary>
        /// <param name="pGameObject">The GameObject to add the behaviour to</param>
        /// <typeparam name="T">The CogBehaviour type</typeparam>
        public T AddBehaviour<T>(GameObject pGameObject) where T : CogBehaviour
        {
            T cogBehaviour = pGameObject.AddComponent<T>();
            cogBehaviour.Init();
            _cogBehaviours.Add(cogBehaviour);

            return cogBehaviour;
        }

        public T LoadBehaviour<T>(string path = "") where T : CogBehaviour
        {
            if (string.IsNullOrEmpty(path))
            {
                path = nameof(T);
            }
            
            T cogBehavior = Instantiate(Resources.Load<T>($"CogBehaviours/{path}"));
            cogBehavior.Init();
            _cogBehaviours.Add(cogBehavior);

            return cogBehavior;
        }

        public void RegisterUpdateFunction(Action<float> pUpdateFunction)
        {
            _cogBehaviourUpdateFunctions.Add(pUpdateFunction);
        }
        
        public void UnregisterUpdateFunction(Action<float> pUpdateFunction)
        {
            _cogBehaviourUpdateFunctions.Remove(pUpdateFunction);
        }
        
        public void RegisterLateUpdateFunction(Action<float> pUpdateFunction)
        {
            _cogBehaviourLateUpdateFunctions.Add(pUpdateFunction);
        }
        
        public void UnregisterLateUpdateFunction(Action<float> pUpdateFunction)
        {
            _cogBehaviourLateUpdateFunctions.Remove(pUpdateFunction);
        }
    }
}