using System;
using LavaProject.Inventory.Abstract;

namespace LavaProject.Inventory
{
    [Serializable]
    public class InventoryItemState : IInventoryItemState
    {
        private int _amount;

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public InventoryItemState()
        {
            _amount = 0;
        }
    }
}