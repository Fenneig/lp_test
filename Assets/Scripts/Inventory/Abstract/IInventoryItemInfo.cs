using UnityEngine;

namespace LavaProject.Inventory.Abstract
{
    public interface IInventoryItemInfo
    {
        string Id { get; }
        Sprite SpriteIcon { get; }
    }
}