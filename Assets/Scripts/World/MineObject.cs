﻿using System.Collections;
using LavaProject.Assets;
using LavaProject.Characters;
using LavaProject.Utils;
using LavaProject.Utils.HUD;
using UnityEngine;

namespace LavaProject.World
{
    public class MineObject : MonoBehaviour
    {
        [Space][Header("Mine asset")]
        [SerializeField] private Mine _mine;

        [Space][Header("System fields")]
        [SerializeField] private SpawnComponent _spawnPosition;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private MeshRenderer _meshRenderer;

        [Space] [Header("HUD")] 
        [SerializeField] private ProgressBar _progressBar;

        private MiningComponent _playerMiningComponent;
        private int _currentOreInSpot;
        private bool _isMineReady;
        private Color _baseColor;

        private void Awake()
        {
            _currentOreInSpot = _mine.MineCapacity;

            _spawnPosition.SetObject(_mine.CollectableItemPrefab);
            _baseColor = _meshRenderer.material.color;

            _isMineReady = true;
        }

        public void StartMining(GameObject target)
        {
            if (_playerMiningComponent != null) return;
            if (!target.TryGetComponent(out _playerMiningComponent)) return;
            _playerMiningComponent.IsMining = _isMineReady;
            _playerMiningComponent.CurrentMine = this;
        }
        
        public void EndMining(GameObject target)
        {
            if (_playerMiningComponent == null) return;
            _playerMiningComponent.IsMining = false;
            _playerMiningComponent.CurrentMine = null;
            _playerMiningComponent = null;
        }

        public void Extract()
        {
            if (_currentOreInSpot > 0)
            {
                _currentOreInSpot--;
                _spawnPosition.Spawn();
                _particle.Play();
            }

            if (_currentOreInSpot == 0)
            {
                _isMineReady = false;
                _playerMiningComponent.IsMining = false;
                StartCoroutine(RefillMine());
            }
        }

        private IEnumerator RefillMine()
        {
            _meshRenderer.material.color = Color.black;
            var time = 0f;
            _progressBar.gameObject.SetActive(true);
            while (time < _mine.MineRefillTime)
            {
                time += Time.deltaTime;
                var progress = time / _mine.MineRefillTime;
                _progressBar.SetProgress(progress);
                yield return null;
            }
            
            _progressBar.gameObject.SetActive(false);
            _meshRenderer.material.color = _baseColor;
            _currentOreInSpot = _mine.MineCapacity;
            _isMineReady = true;
            if (_playerMiningComponent != null)
                _playerMiningComponent.IsMining = true;
        }
    }
}