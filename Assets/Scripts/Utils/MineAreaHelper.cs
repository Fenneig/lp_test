using UnityEngine;

namespace LavaProject.Utils
{
    public class MineAreaHelper : MonoBehaviour
    {
        [SerializeField] private float _mineAreaRadius;
        [SerializeField] private SphereCollider _sphere;
        [SerializeField] private RectTransform _miningAreaImage;

        private void OnValidate()
        {
            _sphere.radius = _mineAreaRadius;
            _miningAreaImage.sizeDelta = new Vector2(_mineAreaRadius * 2, _mineAreaRadius * 2);
        }
    }
}
