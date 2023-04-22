using LavaProject.Inventory;
using LavaProject.Systems;
using LavaProject.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaProject
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private SpawnComponent _playerSpawnPosition;
        private InventoryEndless _inventory;
        private SaveSystem _saveSystem;
        
        public static GameSession Instance { get; private set; }
        public InventoryEndless Inventory => _inventory;
        public GameObject Player { get; private set; }

        private void Awake()
        {
            Instance = this;
            _inventory = new InventoryEndless();
            _saveSystem = new SaveSystem(_inventory);
            LoadHud();
            _saveSystem.LoadData();
            Player = _playerSpawnPosition.Spawn(false);
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
        
        [ContextMenu("Reset save")]
        public void ResetSave()
        {
            SaveSystem.ResetSave();
        }
        
        private void OnApplicationQuit()
        {
            _saveSystem.SaveData();
        }
    }
}
