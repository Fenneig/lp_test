using System.Collections;
using LavaProject.Assets;
using LavaProject.Characters;
using LavaProject.Inventory.Abstract;
using LavaProject.Utils;
using LavaProject.Utils.HUD;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LavaProject.World
{
    public class PlantObject : MonoBehaviour
    {
        [Space] [Header("Plant asset")] 
        [SerializeField] private Plant _plant;

        [Space] [Header("System fields")] 
        [SerializeField] private SpawnComponent _spawnPosition;
        [SerializeField] private MeshRenderer _visualMeshRenderer;

        [Space] [Header("UI elements")] 
        [SerializeField] private Image _imageIconPrice;
        [SerializeField] private TextMeshProUGUI _textPriceAmount;
        [SerializeField] private Image _imageIconOutput;
        [SerializeField] private TextMeshProUGUI _textProduceAmount;
        [SerializeField] private GameObject[] _hudObjectsToHide;
        [SerializeField] private ProgressBar _progressBar;

        private int _itemsLeftForExchange;
        private bool _isPauseBetweenPays;
        private ExchangeComponent _playerExchangeComponent;      
        private Color _baseColor;


        private void Awake()
        {
            _imageIconPrice.sprite = _plant.ObjectPriceAsset.SpriteIcon;
            _textPriceAmount.text = _plant.ObjectsAmountAsPrice.ToString();
            _imageIconOutput.sprite = _plant.ObjectOutputAsset.SpriteIcon;
            _textProduceAmount.text = _plant.ObjectsAmountProduce.ToString();
            _itemsLeftForExchange = _plant.ObjectsAmountAsPrice;
            _spawnPosition.SetObject(_plant.ObjectOutputAsset.CollectableItemPrefab);
            _baseColor = _visualMeshRenderer.material.color;
        }

        public void StartExchange(GameObject target)
        {
            if (_playerExchangeComponent != null) return;
            if (!target.TryGetComponent(out ExchangeComponent exchangeComponent)) return;
            _playerExchangeComponent = exchangeComponent;
            _playerExchangeComponent.SetupExchange(_plant.ObjectPriceAsset.CollectableItemPrefab, this, _itemsLeftForExchange,
                _plant.ObjectPriceAsset.Id);
        }

        public void EndExchange(GameObject target)
        {
            if (_playerExchangeComponent == null) return;
            _playerExchangeComponent.ReadyForExchange = false;
            _playerExchangeComponent = null;
        }

        public void Pickup(object _, IInventoryItem item)
        {
            _itemsLeftForExchange -= item.State.Amount;
            _textPriceAmount.text = _itemsLeftForExchange.ToString();
            
            if (_itemsLeftForExchange == 0)
                StartCoroutine(ExchangeProcess());
        }
        
        private IEnumerator ExchangeProcess()
        {
            var time = 0f;

            SetHudVisibility(false);
            
            while (time <_plant.ProduceTime)
            {
                time += Time.deltaTime;
                var progress = time / _plant.ProduceTime;
                _progressBar.SetProgress(progress);
                yield return null;
            }

            SetHudVisibility(true);
            _spawnPosition.Spawn();
            _itemsLeftForExchange = _plant.ObjectsAmountAsPrice;
            _textPriceAmount.text = _itemsLeftForExchange.ToString();
        }

        private void SetHudVisibility(bool state)
        {
            _visualMeshRenderer.material.color = state ? _baseColor : Color.black;
            _progressBar.gameObject.SetActive(!state);
            foreach (var hudGameObject in _hudObjectsToHide)
            {
                hudGameObject.SetActive(state);
            }
        }
    }
}