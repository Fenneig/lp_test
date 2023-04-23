﻿using LavaProject.Utils;
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
        private GameObject _targetPlant;

        public GameObject Spawn()
        {
            ReadyForExchange = false;
            return _spawnComponent.Spawn();
        }

        private void Update()
        {
            if (!ReadyForExchange || _movementComponent.IsRunning) return;
            if (!GameSession.Instance.Inventory.HasItem(_itemId, out var item)) return;  
            
            var spawnAmount = Mathf.Min(item.State.Amount, _needItemsToSpawn);
            for (int i = 0; i < spawnAmount; i++)
            {
                var exchangeItem = Spawn();
                var collectComponent = exchangeItem.GetComponent<CollectComponent>();
                collectComponent.SetTarget(_targetPlant);
            }

            GameSession.Instance.Inventory.Remove(this, _itemId, spawnAmount);
        }

        public void SetupExchange(GameObject collectableItemPrefab, PlantObject targetPlant, int needItemsToSpawn, string itemId)
        {
            _spawnComponent.SetObject(collectableItemPrefab);
            _targetPlant = targetPlant.gameObject;
            _needItemsToSpawn = needItemsToSpawn;
            _itemId = itemId;
            ReadyForExchange = true;
        }
    }
}