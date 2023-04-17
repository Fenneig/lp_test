using DG.Tweening;
using LavaProject.Assets;
using ObjectPool;
using UnityEngine;

namespace LavaProject.World.Mine
{
    public class CollectComponent : MonoBehaviour
    {
        [SerializeField] private InventoryItemInfo _itemInfo;
        private bool _isReadyToCollect;
        private Item _item;

        private void Awake()
        {
            _item = new Item(_itemInfo) { State = {Amount = 1} };
        }

        public void Collect(GameObject target)
        {
            if (!_isReadyToCollect) return;
            _isReadyToCollect = false;
            
            //TODO : Сделать красивую анимацию движения в игрока через курутины!
            
            var directionToTarget = target.transform.position - transform.position;
            var firstPosition = transform.position - directionToTarget + Vector3.up;
            
            Sequence collectItemSequence = DOTween.Sequence();
            collectItemSequence
                .Append(transform.DOMove(firstPosition, 1))
                .Append(transform.DOMove(target.transform.position, 1))
                .OnComplete(() =>{collectItemSequence.Kill();})
                .OnKill(OnCollectComplete);
        }

        public void PrepareToCollect()
        {
            _isReadyToCollect = true;
        }

        private void OnCollectComplete()
        {
            GameSession.Instance.Inventory.Add(this, _item);
            Pool.Instance.Destroy(gameObject);
        }
    }
}
