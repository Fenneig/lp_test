using UnityEngine;

namespace LavaProject.Assets
{
    [CreateAssetMenu(menuName = "Assets/MineDeposit", fileName = "MineDeposit")]
    public class Mine : ScriptableObject
    {
        [SerializeField] private GameObject _collectableItemPrefab;
        [SerializeField] private int _mineCapacity;
        [SerializeField] private float _mineRefillTime;
       
        public GameObject CollectableItemPrefab => _collectableItemPrefab;
        public int MineCapacity => _mineCapacity;
        public float MineRefillTime => _mineRefillTime;
    }
}