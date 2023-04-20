using System;
using System.Collections.Generic;
using System.Linq;
using LavaProject.Inventory.Abstract;

namespace LavaProject.Inventory
{
    public class InventoryEndless : IInventory
    {
        public event Action<object, IInventorySlot> OnInventoryAddEvent;
        public event Action<object, IInventorySlot> OnInventoryRemoveEvent;

        private List<IInventorySlot> _slots = new ();

        public IInventoryItem GetItem(string itemId) => 
            _slots.FirstOrDefault(slot => slot.Item.Info.Id == itemId)?.Item;

        public IInventoryItem[] GetAllItems()
        {
            var allItems = new List<IInventoryItem>();
            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty) allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetAllItems(string itemId)
        {
            var allItems = new List<IInventoryItem>();

            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty && slot.Item.Info.Id == itemId) allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public int GetItemAmount(string itemId) =>
            _slots.Where(slot => !slot.IsEmpty && slot.Item.Info.Id == itemId).Sum(slot => slot.Amount);


        public void Add(object sender, IInventoryItem item)
        {
            var slotWithSameItem = _slots.Find(slot => !slot.IsEmpty && slot.Item.Info.Id == item.Info.Id);
            if (slotWithSameItem != null)
            {
                AddToSlot(sender, slotWithSameItem, item);
                return;
            }

            var emptySlot = _slots.Find(slot => slot.IsEmpty);
            AddToSlot(sender, emptySlot ?? new InventorySlot(), item);
        }

        private void AddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            var clonedItem = item.Clone();

            if (slot.IsEmpty)
            {
                slot.SetItem(clonedItem);
                _slots.Add(slot);
            }
            else
            {
                slot.Item.State.Amount += item.State.Amount;
            }

            OnInventoryAddEvent?.Invoke(sender, slot);
        }

        public void Remove(object sender, string itemId, int amount = 1)
        {
            var slotWithItem = _slots.Find(slot => slot.Item.Info.Id == itemId);

            slotWithItem.Item.State.Amount -= amount;
            if (slotWithItem.Item.State.Amount <= 0) slotWithItem.Clear();
            
            OnInventoryRemoveEvent?.Invoke(sender, slotWithItem);
        }

        public bool HasItem(string id, out IInventoryItem item)
        {
            item = GetItem(id);
            return item != null;
        }

        public IInventorySlot[] GetAllSlots() => 
            _slots.ToArray();
    }
}