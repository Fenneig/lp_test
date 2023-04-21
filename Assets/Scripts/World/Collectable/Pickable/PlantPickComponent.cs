using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.World.Collectable.Pickable
{
    public class PlantPickComponent : MonoBehaviour, IPickable
    {
        [SerializeField] private PlantObject _plant;
        
        public void Pickup(object sender, IInventoryItem item)
        {
            _plant.Pickup(sender, item);
        }
    }
}