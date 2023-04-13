using UnityEngine;

namespace LavaProject.Utils
{
    public static class GameObjectExtension
    {
        public static bool IsInLayer(this GameObject go, LayerMask layer) =>
            layer == (layer | 1 << go.layer);
    }
}