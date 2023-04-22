using LavaProject.Assets.Definitions.Repositories;
using UnityEngine;

namespace LavaProject.Assets.Definitions
{
    [CreateAssetMenu(menuName = "Assets/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private ItemsRepository _itemsRepository;
        [SerializeField] private MineRepository _mineRepository;
        [SerializeField] private PlantRepository _plantRepository;
        
        public ItemsRepository ItemsRepository => _itemsRepository;
        public MineRepository MineRepository => _mineRepository;
        public PlantRepository PlantRepository => _plantRepository;

        private static DefsFacade _instance;
        public static DefsFacade Instance => _instance == null ? LoadDefs() : _instance;
        
        private static DefsFacade LoadDefs() => _instance = Resources.Load<DefsFacade>("DefsFacade");
    }
}