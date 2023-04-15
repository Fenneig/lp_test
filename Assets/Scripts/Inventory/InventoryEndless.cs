using System;
using System.Collections.Generic;
using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.Inventory
{
    public class InventoryEndless : IInventory
    {
        public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
        public event Action<object, Type, int> OnInventoryItemRemovedEvent;
        private List<IInventorySlot> _slots;

        public InventoryEndless()
        {
            _slots = new List<IInventorySlot>();
        }

        public IInventoryItem GetItem(Type itemType) => 
            _slots.Find(slot => slot.ItemType == itemType).Item;

        public IInventoryItem[] GetAllItems()
        {
            var allItems = new List<IInventoryItem>();
            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty) allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            var allItems = new List<IInventoryItem>();

            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty && slot.ItemType == itemType) allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public int GetItemAmount(Type itemType)
        {
            var itemAmount = 0;

            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty && slot.ItemType == itemType) itemAmount += slot.Amount;
            }

            return itemAmount;
        }


        public void Add(object sender, IInventoryItem item)
        {
            var slotWithSameItem = _slots.Find(slot => !slot.IsEmpty && slot.ItemType == item.Type);
            if (slotWithSameItem != null) AddToSlot(sender, slotWithSameItem, item);

            var emptySlot = _slots.Find(slot => slot.IsEmpty);
            AddToSlot(sender, emptySlot ?? new InventorySlot(), item);
        }

        private void AddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            var clonedItem = item.Clone();

            if (slot.IsEmpty) slot.SetItem(clonedItem);
            else slot.Item.Amount += item.Amount;

            OnInventoryItemAddedEvent?.Invoke(sender, item, item.Amount);
        }

        public void Remove(object sender, Type itemType, int amount = 1)
        {
            var slotWithItem = _slots.Find(item => item.ItemType == itemType);

            slotWithItem.Item.Amount -= amount;
            if (slotWithItem.Item.Amount <= 0) slotWithItem.Clear();
            OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amount);
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            item = GetItem(type);
            return item != null;
        }

        public IInventorySlot[] GetAllSlots() => 
            _slots.ToArray();
    }
}