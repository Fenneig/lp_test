using UnityEngine;
using UnityEngine.UI;

namespace LavaProject.Utils.HUD
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _progress;

        public void SetProgress(float progress)
        {
            _progress.fillAmount = progress;
        }
    }
}
