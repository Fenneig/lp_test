using System.Collections.Generic;
using System.Linq;
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
            _session.Inventory.OnInventoryAddEvent += InventoryAdd;
            _session.Inventory.OnInventoryRemoveEvent += InventoryRemove;
            InitLoadedHud();
        }

        private void InitLoadedHud()
        {
            var slots = _session.Inventory.GetAllSlots();
            foreach (var slot in slots)
            {
                var newSlot = Instantiate(_itemWidgetPrefab, transform);
                _itemsList.Add(newSlot);
                newSlot.UpdateData(slot);
            }
        }

        private void InventoryRemove(object sender, IInventorySlot inventorySlot)
        {
            foreach (var itemWidget in _itemsList)
            {
                if (itemWidget.Slot.IsEmpty) itemWidget.gameObject.SetActive(false);
                else if (!inventorySlot.IsEmpty && itemWidget.Slot.Item.Info.Id == inventorySlot.Item.Info.Id)
                    itemWidget.UpdateData(inventorySlot);
            }
        }

        private void InventoryAdd(object sender, IInventorySlot inventorySlot)
        {
            var existSlot = _itemsList.FirstOrDefault(widget => widget.Slot.Item.Info.Id == inventorySlot.Item.Info.Id);
            if (existSlot != null)
            {
                existSlot.UpdateData(inventorySlot);
                existSlot.gameObject.SetActive(true);
                existSlot.PlayVisualEffect();
            }
            else
            {
                var newSlot = Instantiate(_itemWidgetPrefab, transform);
                _itemsList.Add(newSlot);
                newSlot.UpdateData(inventorySlot);
                newSlot.PlayVisualEffect();
            }
        }
    }
}