using System;
using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.Assets
{
    [CreateAssetMenu(menuName = "Assets/Item", fileName = "Item")]
    public class Item : ScriptableObject, IInventoryItem
    {
        public SpriteRenderer _icon;
        public Type Type => GetType();
        public int Amount { get; set; }
        public IInventoryItem Clone()
        {
             var newItem = CreateInstance<Item>();
             newItem.Amount = Amount;
             return newItem;
        }
    }
}