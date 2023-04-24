using LavaProject.Utils;
using LavaProject.World;
using LavaProject.World.Collectable;
using UnityEngine;

namespace LavaProject.Characters
{
    public class ExchangeComponent : MonoBehaviour
    {
        [SerializeField] private SpawnComponent _spawnComponent;
        [SerializeField] private MovementComponent _movementComponent;

        public bool ReadyForExchange { get; set; }
        
        private int _needItemsToSpawn;
        private string _itemId;
        private PlantObject _targetPlant;

        private GameObject Spawn()
        {
            ReadyForExchange = false;
            return _spawnComponent.Spawn();
        }

        private void Update()
        {
            if (!ReadyForExchange || _movementComponent.IsRunning) return;
            if (!GameSession.Instance.Inventory.HasItem(_itemId, out var item)) return;  
            
            var spawnAmount = Mathf.Min(item.State.Amount, _needItemsToSpawn);
            
            if (spawnAmount == _needItemsToSpawn) _targetPlant.IsExchangeInProgress = true;
            
            for (int i = 0; i < spawnAmount; i++)
            {
                var exchangeItem = Spawn();
                var collectComponent = exchangeItem.GetComponent<CollectComponent>();
                collectComponent.SetTarget(_targetPlant.gameObject);
            }

            GameSession.Instance.Inventory.Remove(this, _itemId, spawnAmount);
        }

        //TODO: Возможно нужну добавить интерфейс для замены PlantObject, чтобы не создавать зависимость от фабрик
        public void SetupExchange(GameObject collectableItemPrefab, PlantObject targetPlant, int needItemsToSpawn, string itemId)
        {
            _spawnComponent.SetObject(collectableItemPrefab);
            _targetPlant = targetPlant;
            _needItemsToSpawn = needItemsToSpawn;
            _itemId = itemId;
            ReadyForExchange = true;
        }
    }
}