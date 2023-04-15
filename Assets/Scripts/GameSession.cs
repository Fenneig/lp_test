using LavaProject.Inventory;
using LavaProject.Inventory.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaProject
{
    public class GameSession : MonoBehaviour
    {
        public static GameSession Instance { get; private set; }

        private IInventory _inventory;

        public IInventory Inventory => _inventory;

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
