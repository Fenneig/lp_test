using ObjectPool;
using UnityEngine;

namespace LavaProject.Utils
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToSpawn;

        public void SetObject(GameObject objectToSpawn)
        {
            _objectToSpawn = objectToSpawn;
        }

        public void Spawn()
        {
            Pool.Instance.Get(_objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}