using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaProject.Systems
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
