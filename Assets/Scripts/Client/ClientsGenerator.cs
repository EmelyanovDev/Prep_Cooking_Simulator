using System.Collections;
using UnityEngine;

namespace Client
{
    public class ClientsGenerator : MonoBehaviour
    {
        [SerializeField] private float createDelay;
        [SerializeField] private float createRange;

        private ClientsPlacesHub _placesHub;
        private Transform _clientCreatePoint;
        private ClientsPool _clientsPool;

        private void Awake()
        {
            _clientsPool = ClientsPool.Instance;
            _placesHub = ClientsPlacesHub.Instance;
            _clientCreatePoint = GetComponent<Transform>();
            
            Random.InitState(Random.Range(0,1000)); 
        }

        private void Start()
        {
            StartCoroutine(TryCreateClients());
        }

        private IEnumerator TryCreateClients()
        {
            while (true)
            {
                yield return new WaitForSeconds(createDelay + Random.Range(-createRange, createRange));

                if (_placesHub.HasEmptyPlace())
                    _clientsPool.ActivateClient(_clientCreatePoint.position, Quaternion.identity);
            }
        }
    }
}
