using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.Assets
{
    [CreateAssetMenu(menuName = "Assets/Item", fileName = "Item")]
    public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;

        public string Id => _id;
        public Sprite SpriteIcon => _icon;
    }
}