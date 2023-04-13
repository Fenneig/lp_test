using UnityEngine;

namespace LavaProject.Characters
{
    public class MiningComponent : MonoBehaviour
    {
        public MineDepositComponent CurrentMine { private get; set; }
        public bool IsMining { get; set; }


        public void PickaxeHit()
        {
            CurrentMine.GetOre();
        }
    }
}