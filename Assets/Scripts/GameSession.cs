using LavaProject.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaProject
{
    public class GameSession : MonoBehaviour
    {
        public static GameSession Instance { get; private set; }

        private InventoryEndless _inventory;

        public InventoryEndless Inventory => _inventory;

        private void Awake()
        {
            Instance = this;
            _inventory = new InventoryEndless();
            LoadHud();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
    }
}
