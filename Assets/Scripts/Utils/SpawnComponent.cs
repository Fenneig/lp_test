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

        public GameObject Spawn()
        {
            return Pool.Instance.Get(_objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}