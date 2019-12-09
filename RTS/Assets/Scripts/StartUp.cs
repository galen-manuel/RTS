using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace COG.RTS
{
    public class StartUp : MonoBehaviour
    {
        public int StartUpScene;

        private void Awake()
        {
            SceneManager.LoadScene(StartUpScene, LoadSceneMode.Additive);
        }
    } 
}
