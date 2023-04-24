using System.Collections;
using DG.Tweening;
using LavaProject.Assets;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LavaProject.World.Collectable
{
    [RequireComponent(typeof(CollectComponent))]
    public class CollectableItem : MonoBehaviour
    {
        private CollectComponent _collectComponent;
        private ItemInfo _itemInfo;

        private void Awake()
        {
            _collectComponent = GetComponent<CollectComponent>();
            _itemInfo = _collectComponent.ItemInfo;
            PlayStartAnimation();
        }
        
        public void PlayStartAnimation()
        {
            var newPosition = new Vector3(Random.Range(-5, 5), -transform.position.y + 1f, Random.Range(-5, 5));
            transform.DOJump(transform.position + newPosition, _itemInfo.JumpForce, 1, _itemInfo.MoveFromMineTime)
                .SetEase(Ease.OutQuart)
                .OnComplete(() => StartCoroutine(OnAnimationEnd()));
        }

        private IEnumerator OnAnimationEnd()
        {
            yield return new WaitForSeconds(_itemInfo.PrepareToCollectTime);
            
            _collectComponent.PrepareToCollect();
            if (_collectComponent.Target != null) 
                _collectComponent.Collect();
        }
    }
}