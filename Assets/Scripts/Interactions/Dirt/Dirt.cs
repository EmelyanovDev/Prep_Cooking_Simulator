using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions.Dirt
{
    public class Dirt : MonoBehaviour
    {
        [SerializeField] private float cleaningTime;
        [SerializeField] private Image timerImage;

        private bool _breakCoroutine;
        private bool _tryingClean;
        private DirtPoint _selfPoint;

        public void Init(DirtPoint dirtPoint) => _selfPoint = dirtPoint;

        private void OnTriggerEnter(Collider other)
        {
            _breakCoroutine = false;

            if (_tryingClean) return;

            StartCoroutine(TryCleanDirt());
        }

        private void OnTriggerExit(Collider other) => _breakCoroutine = true;

        private IEnumerator TryCleanDirt()
        {
            _tryingClean = true;
            
            float delayTime = 0f;
            while (delayTime <= cleaningTime)
            {
                delayTime += Time.deltaTime;
                timerImage.fillAmount = delayTime / cleaningTime;
                
                if (_breakCoroutine)
                {
                    timerImage.fillAmount = 0f;
                    _tryingClean = false;
                    yield break;
                }
                
                yield return null;
            }
            
            _selfPoint.SetBusy(false);
            Destroy(gameObject);

            _tryingClean = false;
            yield return null;
        }
    }
}
