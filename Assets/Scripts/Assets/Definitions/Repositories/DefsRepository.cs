using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LavaProject.Assets.Definitions.Repositories
{
    public class DefsRepository<TDefType> : ScriptableObject where TDefType : IHaveId
    {
        [SerializeField] protected TDefType[] _collection;

        public TDefType Get(string id) =>
            _collection.FirstOrDefault(item => item.Id == id);

        public TDefType[] GetAll =>
            new List<TDefType>(_collection).ToArray();
    }
}