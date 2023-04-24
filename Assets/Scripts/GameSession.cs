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
        public bool IsTutorialComplete => _saveSystem.IsTutorialComplete;

        private void Awake()
        {
            var existSessions = GetExistSession();

            if (existSessions != null)
            {
                existSessions.StartSession();
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
                _inventory = new InventoryEndless();
                _saveSystem = new SaveSystem(_inventory);
                StartSession();
            }
        }

        private GameSession GetExistSession()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach (var gameSession in sessions)
            {
                if (gameSession != this)
                    return gameSession;
            }

            return null;
        }

        private void StartSession()
        {
            LoadHud();
            SpawnHero();
            _saveSystem.LoadData();
        }

        private void SpawnHero()
        {
            Player = _playerSpawnPosition.Spawn(false);

        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }

        private void OnApplicationQuit()
        {
            _saveSystem.SaveData();
        }

        public void CompleteTutorial()
        {
            _saveSystem.IsTutorialComplete = true;
        }

        [ContextMenu("Reset save")]
        public void ResetSave()
        {
            SaveSystem.ResetSave();
        }
    }
}
