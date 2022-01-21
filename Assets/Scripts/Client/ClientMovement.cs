using UnityEngine;
using UnityEngine.AI;

namespace Client
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClientMovement : MonoBehaviour
    {
        private ClientsPlace _clientsPlace;
        private ClientsPlacesHub _clientsPlacesHub;
        private NavMeshAgent _navMeshAgent;
        private Transform _selfTransform;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _selfTransform = GetComponent<Transform>();
            _clientsPlacesHub = ClientsPlacesHub.Instance;
        }
        
        public void Activating()
        {
            _clientsPlace = _clientsPlacesHub.GetEmptyPlace();
            if(_clientsPlace != null)
                _navMeshAgent.SetDestination(_clientsPlace.TakePlace(this).position);
        }

        public void FreeUpPlace()
        {
            _clientsPlace = null;
            _navMeshAgent.SetDestination(_clientsPlacesHub.GetExitPoint().position);
        }

        public void Transforming(Vector3 position, Quaternion rotation)
        {
            _selfTransform.position = position;
            _selfTransform.rotation = rotation;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ClientsPlace clientsPlace) && clientsPlace == _clientsPlace && !clientsPlace.RecipeIsCreated())
                clientsPlace.CreateNewOrder();
        }
    }
}
