using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.World.Collectable.Pickable
{
    public class PlayerPickComponent : MonoBehaviour, IPickable
    {
        public void Pickup(object sender, IInventoryItem item)
        {
            GameSession.Instance.Inventory.Add(sender, item);
        }
    }
}