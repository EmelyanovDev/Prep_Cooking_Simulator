using UnityEngine;
using UnityEngine.AI;

namespace Client
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class ClientMovement : MonoBehaviour
    {
        private PlaceInteraction _currentPlace;
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
            
            _currentPlace = _clientsPlacesHub.GetEmptyPlace();
            if (_currentPlace != null)
            {
                _navMeshAgent.SetDestination(_currentPlace.TakePlace(this).position);
            }
        }

        public void FreeUpPlace()
        {
            _currentPlace = null;
            _navMeshAgent.SetDestination(_clientsPlacesHub.GetExitPoint().position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlaceInteraction clientsPlace) && clientsPlace == _currentPlace && _madeOrder == false)
            {
                clientsPlace.CreateNewOrder();
                _madeOrder = true;
            }
        }
    }
}
