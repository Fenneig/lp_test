using LavaProject.Assets.Definitions;
using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.Assets
{
    [CreateAssetMenu(menuName = "Assets/CollectableItem", fileName = "CollectableItem")]
    public class ItemInfo : ScriptableObject, IInventoryItemInfo, IHaveId
    {
        [SerializeField] private string _id;
        [Space][Header("UI Info")]
        [SerializeField] private Sprite _icon;

        [Space] [Header("Gameplay info")]
        [SerializeField] private GameObject _collectableItemPrefab;
        [SerializeField] private float _prepareToCollectTime;
        [Space][Header("Mine visual info")]
        [SerializeField] private float _moveFromMineTime;
        [SerializeField] private float _jumpForce;

        public string Id => _id;
        public Sprite SpriteIcon => _icon;
        public GameObject CollectableItemPrefab => _collectableItemPrefab;
        public float PrepareToCollectTime => _prepareToCollectTime;
        public float MoveFromMineTime => _moveFromMineTime;
        public float JumpForce => _jumpForce;
    }
}