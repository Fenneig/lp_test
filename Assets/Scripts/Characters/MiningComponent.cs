using LavaProject.World.Collectable;
using UnityEngine;

namespace LavaProject.Characters
{
    public class MiningComponent : MonoBehaviour
    {
        public MineDeposit CurrentMine { private get; set; }
        public bool IsMining { get; set; }

        public void PickaxeHit()
        {
            if (CurrentMine != null)
                CurrentMine.Extract();
        }
    }
}