using System;
using System.Collections;
using Client;
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

        private CollectingItem _pickedItem;
        private bool _tryingCollect;
        private bool _brakeCoroutines;

        private void OnTriggerEnter(Collider other)
        {
            _brakeCoroutines = false;
            
            if(_tryingCollect) return;
            
            if (_pickedItem == null)
            {
                if (other.TryGetComponent(out ItemsContainer itemsContainer) && itemsContainer.CanPickItem())
                    StartCoroutine(TryPickItem(itemsContainer.TakeItem));
                else if (other.TryGetComponent(out PuttingPlace puttingPlace) && puttingPlace.CanCollectItem(false))
                    StartCoroutine(TryPickItem(puttingPlace.TakeItem));
                else if (other.TryGetComponent(out CollectingPlace collectingPlace) && collectingPlace.HasContainedItem())
                    StartCoroutine(TryPickItem(collectingPlace.PickItem));
            }
            else
            {
                if (other.TryGetComponent(out PuttingPlace puttingPlace) && puttingPlace.CanCollectItem(true) )
                    StartCoroutine(TryPutItem(puttingPlace.GetItemPoint));
                else if (other.TryGetComponent(out Trashcan trashcan))
                    StartCoroutine(TryPutItem(trashcan.GetTrashPoint));
                else if (other.TryGetComponent(out CollectingPlace collectingPlace))
                    StartCoroutine(TryPutItem(collectingPlace.PutItem));
                else if (other.TryGetComponent(out ClientsPlace clientsPlace) && clientsPlace.CanPutItem())
                    StartCoroutine(TryPutItem(clientsPlace.PutItem));
                else if (other.TryGetComponent(out ItemsContainer itemsContainer))
                    StartCoroutine(TryPutItem(itemsContainer.PutItem));
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            _brakeCoroutines = true;
        }

        private IEnumerator TryPickItem(Func<CollectingItem> func)
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

        private IEnumerator TryPutItem(Func<CollectingItem, Vector3> func)
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
