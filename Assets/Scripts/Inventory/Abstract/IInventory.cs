namespace LavaProject.Inventory.Abstract
{
    public interface IInventory
    {
        IInventoryItem GetItem(string itemId);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(string itemId);
        int GetItemAmount(string itemId);

        void Add(object sender, IInventoryItem item);
        void Remove(object sender, string itemId, int amount = 1);
        bool HasItem(string id, out IInventoryItem item);
    }
}