using System.Collections.Generic;
using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.Inventory.UI
{
    public class InventoryWidget : MonoBehaviour
    {
        [SerializeField] private ItemWidget _itemWidgetPrefab;

        private List<ItemWidget> _itemsList;

        private GameSession _session;
        
        private void Start()
        {
            _session = GameSession.Instance;
            _itemsList = new List<ItemWidget>();
            _session.Inventory.OnInventoryChangedEvent += InventoryChanged;
        }

        private void InventoryChanged(object sender, IInventorySlot inventorySlot)
        {
            Debug.Log("Inventory changed!");
            var existSlot = _itemsList.Find(widget => widget.Slot.Item.Info.Id == inventorySlot.Item.Info.Id);
            if (existSlot != null)
            {
                existSlot.UpdateData(inventorySlot);
            }
            else
            {
                var newSlot = Instantiate(_itemWidgetPrefab, transform);
                _itemsList.Add(newSlot);
                newSlot.UpdateData(inventorySlot);
            }
        }
        
    }
}