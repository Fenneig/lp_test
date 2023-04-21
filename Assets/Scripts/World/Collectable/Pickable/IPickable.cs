using LavaProject.Inventory.Abstract;

namespace LavaProject.World.Collectable.Pickable
{
    public interface IPickable
    {
        public void Pickup(object sender, IInventoryItem item);
    }
}