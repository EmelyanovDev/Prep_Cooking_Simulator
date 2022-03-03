using System;
using UnityEngine;
using UnityEngine.AI;

namespace Client
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class ClientMovement : MonoBehaviour
    {
        private PlaceInteraction _placeInteraction;
        private ClientsPlacesHub _clientsPlacesHub;
        private NavMeshAgent _navMeshAgent;
        private Transform _selfTransform;
        private bool _madeOrder;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _selfTransform = GetComponent<Transform>();
            
            _clientsPlacesHub = ClientsPlacesHub.Instance;
        }
        
        public void Activating(Vector3 position)
        {
            _selfTransform.position = position;
            gameObject.SetActive(true);
            
            _placeInteraction = _clientsPlacesHub.GetEmptyPlace();
            if (_placeInteraction != null)
            {
                _navMeshAgent.SetDestination(_placeInteraction.TakePlace(this).position);
            }
        }

        public void FreeUpPlace()
        {
            _placeInteraction = null;
            _navMeshAgent.SetDestination(_clientsPlacesHub.GetExitPoint().position);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlaceInteraction clientsPlace) && clientsPlace == _placeInteraction && _madeOrder == false)
            {
                clientsPlace.CreateNewOrder();
                _madeOrder = true;
            }
        }
    }
}
