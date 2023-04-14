using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaProject
{
    public class GameSession : MonoBehaviour
    {
        
        public GameSession Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            LoadHud();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
    }
}
