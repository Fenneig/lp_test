using UnityEngine;

namespace LavaProject.Assets
{    
    [CreateAssetMenu(menuName = "Assets/Plant", fileName = "Plant")]
    public class Plant : ScriptableObject
    {
        [SerializeField] private ItemInfo _objectPriceAsset;
        [SerializeField] private ItemInfo _objectOutputAsset;
        [SerializeField] private int _objectsAmountAsPrice;
        [SerializeField] private int _objectsAmountProduce;
        [SerializeField] private float _produceTime;

        public ItemInfo ObjectPriceAsset => _objectPriceAsset;
        public ItemInfo ObjectOutputAsset => _objectOutputAsset;
        public int ObjectsAmountAsPrice => _objectsAmountAsPrice;
        public int ObjectsAmountProduce => _objectsAmountProduce;
        public float ProduceTime => _produceTime;
    }
}