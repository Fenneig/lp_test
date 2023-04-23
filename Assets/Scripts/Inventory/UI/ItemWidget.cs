using LavaProject.Inventory.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LavaProject.Inventory.UI
{
    public class ItemWidget : MonoBehaviour
    {
        [SerializeField] private Image _imageIcon;
        [SerializeField] private TextMeshProUGUI _textAmount;
        [SerializeField] private ParticleSystem _particle;

        public IInventorySlot Slot { get; private set; }

        public void UpdateData(IInventorySlot slot)
        {
            if (slot.IsEmpty)
            {
                Clear();
                return;
            }

            Slot = slot;
            _imageIcon.sprite = slot.Item.Info.SpriteIcon;
            _textAmount.text = slot.Amount.ToString();
        }

        private void Clear()
        {
            _imageIcon.gameObject.SetActive(false);
            _textAmount.gameObject.SetActive(false);
        }

        public void PlayVisualEffect()
        {
            _particle.Play();
        }
    }
}