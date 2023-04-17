using UnityEngine;

namespace LavaProject.Assets
{
    [CreateAssetMenu(menuName = "Assets/MineDeposit", fileName = "MineDeposit")]
    public class Mine : ScriptableObject
    {
        [SerializeField] private ItemInfo _objectToSpawnAsset;
        [SerializeField] private int _mineCapacity;
        [SerializeField] private float _mineRefillTime;

        public ItemInfo ObjectToSpawn => _objectToSpawnAsset;

        public int MineCapacity => _mineCapacity;

        public float MineRefillTime => _mineRefillTime;
    }
}