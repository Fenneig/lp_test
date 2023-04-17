using System.Collections;
using LavaProject.Characters;
using LavaProject.Utils;
using UnityEngine;

namespace LavaProject.World.Mine
{
    public class MineDeposit : MonoBehaviour
    {
        [SerializeField] private int _oreCapacity = 5;
        [SerializeField] private float _refillMineTime = 10f;
        [SerializeField] private SpawnComponent _spawnPosition;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private MiningComponent _playerMiningComponent;
        private int _currentOreInSpot;
        private bool _isMineReady;

        private void Start()
        {
            _currentOreInSpot = _oreCapacity;
            _isMineReady = true;
        }

        public void StartMining(GameObject target)
        {
            if (_playerMiningComponent == null)
            {
                if (!target.TryGetComponent(out _playerMiningComponent))
                {
                    return;
                }
            }
            
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
            yield return new WaitForSeconds(_refillMineTime);
            _meshRenderer.material.color = Color.white;

            _currentOreInSpot = _oreCapacity;
            _isMineReady = true;
            if (_playerMiningComponent != null)
                _playerMiningComponent.IsMining = true;
        }
    }
}