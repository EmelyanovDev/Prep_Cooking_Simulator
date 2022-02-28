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
        
        public void Activating(Vector3 position)
        {
            _selfTransform.position = position;
            gameObject.SetActive(true);
            
            _clientsPlace = _clientsPlacesHub.GetEmptyPlace();
            if (_clientsPlace != null)
            {
                _navMeshAgent.SetDestination(_clientsPlace.TakePlace(this).position);
            }
        }

        public void FreeUpPlace()
        {
            _clientsPlace = null;
            _navMeshAgent.SetDestination(_clientsPlacesHub.GetExitPoint().position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ClientsPlace clientsPlace) && clientsPlace == _clientsPlace && clientsPlace.RecipeIsCreated() == false)
            {
                clientsPlace.CreateNewOrder();
            }
        }
    }
}
