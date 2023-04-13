using LavaProject.Characters;
using UnityEngine;

namespace LavaProject
{
    public class MineDepositComponent : MonoBehaviour
    {
        public void StartMining(GameObject target)
        {
            target.TryGetComponent<MiningComponent>(out var miningComponent);
            miningComponent.IsMining = true;
            miningComponent.CurrentMine = this;
        }
        
        public void EndMining(GameObject target)
        {
            target.TryGetComponent<MiningComponent>(out var miningComponent);
            miningComponent.IsMining = false;
            miningComponent.CurrentMine = null;
        }

        public void GetOre()
        {
            Debug.Log($"try get ore from {name}");
        }
    }
}