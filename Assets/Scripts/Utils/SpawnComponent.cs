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

        public GameObject Spawn(bool isPoolItem = true)
        {
            return isPoolItem ? 
                Pool.Instance.Get(_objectToSpawn, transform.position, Quaternion.identity) : 
                Instantiate(_objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}