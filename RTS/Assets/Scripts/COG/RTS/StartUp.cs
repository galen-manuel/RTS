using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace COG.RTS
{
    public class StartUp : MonoBehaviour
    {
        public string StartUpSceneName;

        private void Start()
        {
            // Create CogBehaviourSystem
            GameObject cogBehaviourSystemGo = new GameObject("CogBehaviourSystem");
            MasterSystem.Instance.RegisterSystem(cogBehaviourSystemGo.AddComponent<CogBehaviourSystem>());
            
            SceneManager.LoadScene(StartUpSceneName, LoadSceneMode.Additive);
        }
    } 
}
