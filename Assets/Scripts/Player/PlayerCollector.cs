using System;
using System.Collections;
using Interactions;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerCollector : MonoBehaviour
    {
        [SerializeField] private Image collectingIndicator;
        [SerializeField] private Transform pickingPoint;
        [SerializeField] private float collectDelay;
        [SerializeField] private float collectSpeed;

        private Item _pickedItem;
        private bool _tryingCollect;
        private bool _brakeCoroutines;

        private void OnTriggerEnter(Collider other)
        {
            _brakeCoroutines = false;

            if(_tryingCollect) return;

            if (_pickedItem == null && other.TryGetComponent(out IPickItem pick) && pick.CanPickItem())
            {
                StartCoroutine(TryPickItem(pick.PickItem));
            }
            else if (_pickedItem != null && other.TryGetComponent(out IPutItem put) && put.CanPutItem())
            {
                StartCoroutine(TryPutItem(put.PutItem));
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            _brakeCoroutines = true;
        }

        private IEnumerator TryPickItem(Func<Item> func)
        {
            _tryingCollect = true;

            var delayTime = 0f;
            while (delayTime <= collectDelay)
            {
                delayTime += Time.deltaTime;
                collectingIndicator.fillAmount = delayTime / collectDelay;
                
                if(_brakeCoroutines)
                {
                    collectingIndicator.fillAmount = 0f;   
                    _tryingCollect = false;
                    yield break;
                }
                yield return null;
            }
            
            var item = func();
            item.SetTargetTransform(pickingPoint, collectSpeed);
            _pickedItem = item;

            _tryingCollect = false;
            yield return null;
        }

        private IEnumerator TryPutItem(Func<Item, Vector3> func)
        {
            _tryingCollect = true;

            float delayTime = collectDelay;
            while (delayTime >= 0f)
            {
                delayTime -= Time.deltaTime;
                collectingIndicator.fillAmount = delayTime / collectDelay;
                
                if(_brakeCoroutines)
                {
                    collectingIndicator.fillAmount = 1f;
                    _tryingCollect = false;
                    yield break;
                }
                yield return null;
            }

            StartCoroutine(_pickedItem.MoveToPosition(func(_pickedItem), collectSpeed));
            _pickedItem = null;
            
            _tryingCollect = false;
            yield return null;
        }
    }
}
