using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaProject
{
    public class GameSession : MonoBehaviour
    {
        private void Awake()
        {
            LoadHud();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
    }
}
