using UnityEngine;

namespace LavaProject
{
    public class TestScript : MonoBehaviour
    {
        public void SayHisName(GameObject target)
        {
            Debug.Log(target.name);
        }
    }
}